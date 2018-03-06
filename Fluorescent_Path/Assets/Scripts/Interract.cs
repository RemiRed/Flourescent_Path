using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interract : MonoBehaviour
{
    GameObject carriedObject;
    
	[SerializeField] [Range(0.001f, int.MaxValue)]
    float carryDistance;
    [SerializeField][Range(0.001f, int.MaxValue)]
    float carrySpeed;
	[SerializeField][Range(0.001f, int.MaxValue)]
	float slow;

    Vector3 oldPos;

    float defaultDrag;

	bool carrying = false;
    
	void Start()
    {
        defaultDrag = transform.parent.GetComponent<Rigidbody>().drag;
    }

    void FixedUpdate()
    {
		if (Input.GetButtonDown("Interract"))
        {
            if (carrying)
            {
                Drop();
            }
            else
            {
                Pickup();
            }
        }

        if (carrying && carriedObject != null)
        {	
			carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            oldPos = carriedObject.transform.position = 
				Vector3.Lerp(carriedObject.transform.position, transform.position + transform.forward * (carryDistance + carriedObject.GetComponent<Collider>().bounds.extents.x), Time.deltaTime * carrySpeed);
        }
    }
		
    void Pickup()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, carryDistance))
        {
            if (hit.transform.tag == "Movable")
            {
                carrying = true;
                carriedObject = hit.transform.gameObject;
				carriedObject.transform.parent = transform;

                carriedObject.GetComponent<Rigidbody>().useGravity = false;
                carriedObject.GetComponent<Rigidbody>().freezeRotation = true;
                transform.parent.GetComponent<Rigidbody>().drag += carriedObject.GetComponent<Rigidbody>().mass;

				Physics.IgnoreCollision (GetComponentInParent<Collider> (), carriedObject.GetComponent<Collider> (),true);
            }
			if (hit.transform.tag == "Interractable" && hit.transform.gameObject.GetComponent<Interractable>().active)
            {
                hit.transform.gameObject.GetComponent<Interractable>().Interract();
            }
        }
    }

    void Drop()
    { 
		carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;    
        carriedObject.GetComponent<Rigidbody>().freezeRotation = false;
        transform.parent.GetComponent<Rigidbody>().drag = defaultDrag;

		Physics.IgnoreCollision (GetComponentInParent<Collider> (), carriedObject.GetComponent<Collider> (),false);

		carriedObject.GetComponent<Rigidbody>().AddForce((carriedObject.transform.position - oldPos) / (Time.deltaTime * slow));

		carriedObject.transform.parent = null;
		carriedObject = null;
		carrying = false;
    }
}