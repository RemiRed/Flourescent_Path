using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interract : MonoBehaviour
{
    bool carrying = false;
    GameObject carriedObject;
    
	[SerializeField]
    [Range(0.001f, int.MaxValue)]
    float carryDistance;
    
	[SerializeField]
    [Range(0.001f, int.MaxValue)]
    float carrySpeed;

    bool keyUp = true;

    Vector3 oldPos;

    [SerializeField]
    [Range(0.001f, int.MaxValue)]
    float slow;

    float defaultDrag;
    
	private void Start()
    {
        defaultDrag = transform.parent.GetComponent<Rigidbody>().drag;
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Interract") == 1 && keyUp)
        {
            keyUp = false;
            if (carrying)
            {
                Drop();
            }
            else
            {
                Pickup();
            }
        }
        else if (Input.GetAxisRaw("Interract") == 0)
        {
            keyUp = true;
        }

        if (carrying && carriedObject != null)
        {
            carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            oldPos = carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, transform.position + transform.forward * carryDistance, Time.deltaTime * carrySpeed);
            carriedObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
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
                carriedObject.GetComponent<Rigidbody>().useGravity = false;
                carriedObject.GetComponent<Rigidbody>().freezeRotation = true;
                carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                carriedObject.transform.parent = transform;
                transform.parent.GetComponent<Rigidbody>().drag += carriedObject.GetComponent<Rigidbody>().mass;
                Physics.IgnoreCollision(carriedObject.GetComponent<Collider>(), GetComponentInParent<Collider>(), true);
            }
            if (hit.transform.tag == "Interractable")
            {
                hit.transform.gameObject.GetComponent<Interractable>().Interract();
            }
        }
    }

    void Drop()
    {
        carriedObject.GetComponent<Rigidbody>().AddForce((carriedObject.transform.position - oldPos) / (Time.deltaTime * slow));
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().freezeRotation = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.transform.parent = null;
        Physics.IgnoreCollision(carriedObject.GetComponent<Collider>(), GetComponentInParent<Collider>(), false);
        carriedObject = null;
        transform.parent.GetComponent<Rigidbody>().drag = defaultDrag;
    }
}