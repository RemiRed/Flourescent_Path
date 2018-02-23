using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public float movementSpeed = 5f;

	public Rigidbody rigB;

	public GameObject viewCamera;


	// Use this for initialization
	void Start () {

		if (GetComponent<Rigidbody> () != null) {
			rigB = GetComponent<Rigidbody> ();

		} else {
			Debug.LogError ("No Rigidbody attached to gameObject");
		}
	}

	void FirstPersonMouseView(){

		Vector3 rot = new Vector3 (0f, 0f, 0f);
		Vector3 camRot = new Vector3 (0f,0f,0f);

		if (Input.GetAxis("Mouse X") < 0)
		{
			rot.y -= 1;
		}
		// rotates Camera Left
		if (Input.GetAxis("Mouse X") > 0)
		{
			rot.y += 1;
		}

		// rotates Camera Up
		if (Input.GetAxis("Mouse Y") < 0)
		{
			camRot.x += 1;
		}
		// rotates Camera Down
		if (Input.GetAxis("Mouse Y") > 0)
		{
			camRot.x -= 1;
		}

		viewCamera.transform.Rotate (camRot, 35f * Time.deltaTime);
		transform.Rotate(rot, 75f * Time.deltaTime);

	}


	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Vertical") > 0) {

		//	Debug.Log ("Forward");

		} else if (Input.GetAxis ("Vertical") < 0) {

		//	Debug.Log ("Backwards");
		}

		if (Input.GetAxis ("Horizontal") > 0) {

		//	Debug.Log ("Right");

		} else if (Input.GetAxis ("Horizontal") < 0) {

		//	Debug.Log ("Left");
		}

		//rigB.velocity (new Vector3 ());

		rigB.AddRelativeForce(Input.GetAxisRaw ("Vertical") * movementSpeed, 0, Input.GetAxis ("Horizontal") * movementSpeed,ForceMode.Force);


		FirstPersonMouseView ();

	}
}
