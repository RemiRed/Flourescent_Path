using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float jumpPower;

    float gravity = 0.0f;

    Rigidbody rigby;
    Collider collider;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        rigby = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        rigby.AddRelativeForce(Input.GetAxisRaw("Horizontal") * movementSpeed, 0, Input.GetAxisRaw("Vertical") * movementSpeed, ForceMode.Force);

        if(Input.GetAxisRaw("Jump") !=0 && IsGrounded())
        {
            rigby.AddRelativeForce(0, jumpPower, 0);
        }

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
        if (!IsGrounded())
        {
            gravity -= 5;
            rigby.AddRelativeForce(0, gravity, 0);
        }
        else
        {
            gravity = 0;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, collider.bounds.extents.y + 0.1f);
    }
}
