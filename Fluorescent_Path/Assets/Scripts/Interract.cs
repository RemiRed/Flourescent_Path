using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interract : MonoBehaviour
{ 
	GameObject carriedObject;							//The currently carried object 

	[SerializeField][Range(0.001f, int.MaxValue)]
    float carryDistance;								//The distance at which the player interacts with and carries objects 
	[SerializeField][Range(0.001f, int.MaxValue)]
    float normalizeSpeed;								//The speed carried objects return to a normalized position after being dislocated 
	[SerializeField][Range(0.001f, int.MaxValue)]
	float slow;

	Vector3 oldPos;										//The carried objects previous position. Used to calculate position normalization and throwing 

	float defaultDrag;									//The players default drag. Used to reset a players movement speed after movement speed adjustments

	bool carrying = false;								//If the player is currently carrying an object

	private void Start()
    {
		//Sets the defaultDrag variable
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
			carriedObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			oldPos = carriedObject.transform.position 
			= Vector3.Lerp(carriedObject.transform.position, transform.position + transform.forward * (carryDistance + carriedObject.GetComponent<Collider>().bounds.extents.x), Time.deltaTime * normalizeSpeed);
        }
    }

    void Pickup()
    {	
		//Defines a Raycast from camera view
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
		RaycastHit hit;

		//Determines if raycast hit an object
		if (Physics.Raycast (ray, out hit, carryDistance)) {
			//Determines what kind of relevant object the raycast hit
			if (hit.transform.tag == "Movable") {

				//sets changes to carry a movable object
				carrying = true;
				carriedObject = hit.transform.gameObject;
				carriedObject.transform.parent = transform;

				carriedObject.GetComponent<Rigidbody> ().useGravity = false;
				carriedObject.GetComponent<Rigidbody> ().freezeRotation = true;
				transform.parent.GetComponent<Rigidbody> ().drag += carriedObject.GetComponent<Rigidbody> ().mass;
				Physics.IgnoreCollision (carriedObject.GetComponent<Collider> (), GetComponentInParent<Collider> (), true);
			}
			//Calls method in interactible object if object is active
			else if (hit.transform.tag == "Interractable" && hit.transform.GetComponent<Interractable>().active)
            {
				hit.transform.GetComponent<Interractable>().Interract();
            }

        }
    }
		
    void Drop()
    {
		//Resets changes to to no longer carry an object
		carriedObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject.GetComponent<Rigidbody>().freezeRotation = false; 
		transform.parent.GetComponent<Rigidbody>().drag = defaultDrag;
		Physics.IgnoreCollision(carriedObject.GetComponent<Collider>(), GetComponentInParent<Collider>(), false);

		carriedObject.GetComponent<Rigidbody>().AddForce((carriedObject.transform.position - oldPos) / (Time.deltaTime * slow));

		carriedObject.transform.parent = null; 
		carriedObject = null;
		carrying = false;
    }
}