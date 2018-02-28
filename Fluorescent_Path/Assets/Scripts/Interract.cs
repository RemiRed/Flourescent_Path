﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interract : MonoBehaviour
{
    [SerializeField]
    [Range(0.001f, int.MaxValue)]
    float carryDistance; //The distance between the player and the carried object
    [SerializeField]
    [Range(0.001f, int.MaxValue)]
    float carrySpeed; //The speed the object travels to "catch up" to a player after being stuck
    [SerializeField]
    [Range(0.001f, int.MaxValue)]
    float slow; //Modifier for the force added to the object to simulate throwing

    GameObject carriedObject;

    bool keyUp = true;
    bool carrying = false;

    Vector3 oldPos; //Old position, used to calculate the force to emulate throwing



    float defaultDrag;
    private void Start() //saving the drag on the player component
    {
        defaultDrag = transform.parent.GetComponent<Rigidbody>().drag;
    }

    void FixedUpdate() 
    {
        if (Input.GetAxisRaw("Interract") == 1 && keyUp) //Checks if the key has been pressed and picks up, interracts, or drops an object
        {
            keyUp = false;
            if (carrying)
            {
                Drop();
            }
            else
            {
                PickupInterract();
            }
        }
        else if (Input.GetAxisRaw("Interract") == 0) //checks for a key release and allows the player to press the button again
        {
            keyUp = true;
        }

        if (carrying && carriedObject != null) //Returns the object close to the player should it get stuck
        {
            carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            oldPos = carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, transform.position + transform.forward * carryDistance, Time.deltaTime * carrySpeed);
        }
    }




    void PickupInterract()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, carryDistance)) //Finds an object that's within carry distance 
        {

            if (hit.transform.tag == "Movable") //If the object is movable it starts moving the object around
            {
                carrying = true;
                carriedObject = hit.transform.gameObject;
                carriedObject.GetComponent<Rigidbody>().useGravity = false;
                carriedObject.GetComponent<Rigidbody>().freezeRotation = true;
                carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                carriedObject.transform.parent = transform;
                transform.parent.GetComponent<Rigidbody>().drag += carriedObject.GetComponent<Rigidbody>().mass;
            }
            if (hit.transform.tag == "Interractable") //If the object is interractable, like a button, it'll interract with the object
            {
                hit.transform.gameObject.GetComponent<Interractable>().Interract();
            }
        }
    }

    void Drop() //drops a held object
    {
        carriedObject.GetComponent<Rigidbody>().AddForce((carriedObject.transform.position - oldPos) / (Time.deltaTime * slow));
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().freezeRotation = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.transform.parent = null;
        carriedObject = null;
        transform.parent.GetComponent<Rigidbody>().drag = defaultDrag;
    }
}