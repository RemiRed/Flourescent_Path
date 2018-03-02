using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
	[SerializeField]
	float gravity = 5f;
    [SerializeField]
    float jumpPower;
	[SerializeField]
	float minJumpPower;
	[SerializeField]
	float maxJumpPower;


	float curJumpPower;

    Rigidbody rigby;
    Collider collider;

	bool grounded;
	bool jumping;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigby = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
		//Disables the annoying cursor lock
		if (Input.GetKeyDown("escape"))
			Cursor.lockState = CursorLockMode.None;
       
		//Checks if player can jump (and not already jumped)
		if (IsGrounded() && curJumpPower <= 0)
        {
     		//Sets jump value when jump button is pressed down
			if(Input.GetButtonDown("Jump")){

				curJumpPower = minJumpPower;
				jumping = true;

			}else{

				//Sets jump value to a neutral value while grounded
				curJumpPower = 0;
			}
				
		}else{

			//Increases fall speed while not grounded up to a max value
			curJumpPower = Mathf.Max (curJumpPower -= gravity, -250f);
		} 

		if (jumping && Input.GetButton ("Jump")) {

			Debug.Log ("Jumping! :" + curJumpPower);
			curJumpPower = Mathf.Min (curJumpPower += jumpPower, maxJumpPower);

			if (curJumpPower >= maxJumpPower) {

				jumping = false;
			}

		} else {
		
			jumping = false;
		}
    }

	void FixedUpdate(){

		//Executes all movements determined by active axis and currenty jump value 
		rigby.AddRelativeForce(Input.GetAxisRaw("Horizontal Movement") * movementSpeed, curJumpPower, Input.GetAxisRaw("Vertical Movement") * movementSpeed, ForceMode.Force);
	}

    bool IsGrounded()
    {
		//Runs Raycasts to determine if grounded or not. Uses a triad of raycasts for smoother edge detection.
		if (Physics.Raycast (transform.position + new Vector3(0,0,collider.bounds.extents.x/2), -Vector3.up, collider.bounds.extents.y + 0.1f)) {
			grounded = true;
		} else if (Physics.Raycast (transform.position + new Vector3(collider.bounds.extents.x/2,0,collider.bounds.extents.x/2) , -Vector3.up, collider.bounds.extents.y + 0.1f)) {
			grounded = true;
		} else if (Physics.Raycast (transform.position+ new Vector3(-collider.bounds.extents.x/2,0,-collider.bounds.extents.x/2), -Vector3.up, collider.bounds.extents.y + 0.1f)) {
			grounded = true;
		} else {
			grounded = false;
		}
		return grounded; 
    }
}