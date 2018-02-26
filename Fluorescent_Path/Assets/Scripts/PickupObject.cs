using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    bool carrying;
    GameObject carriedObject;
    [SerializeField]
    float carryDistance;
    [SerializeField]
    float smoothing;

    void Update()
    {
        if (carrying)
        {
            carriedObject.GetComponent<Rigidbody>().freezeRotation = true;
            Carry(carriedObject);
            CheckDrop();
        }
        else
        {
            Pickup();
        }
    }


    void Carry(GameObject movable)
    {
        
        movable.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(movable.transform.position, transform.position + transform.forward * carryDistance, Time.deltaTime * smoothing));
    }

    void Pickup()
    {
        if (Input.GetAxisRaw("Interract") >= .5f)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,carryDistance))
            {

                if (hit.transform.tag == "Movable")
                {
                    carrying = true;
                    carriedObject = hit.transform.gameObject;
                    hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
    }

    void CheckDrop()
    {
        if (Input.GetAxisRaw("Interract") <= .5f)
        {
            carriedObject.GetComponent<Rigidbody>().freezeRotation = false;
            DropObject();
        }
    }

    void DropObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }
}