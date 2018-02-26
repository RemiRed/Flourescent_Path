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
            carry(carriedObject);
            checkDrop();
        }
        else
        {
            pickup();
        }
    }


    void carry(GameObject movable)
    {
        movable.transform.position = Vector3.Lerp(movable.transform.position, transform.position + transform.forward * carryDistance, Time.deltaTime * smoothing);

    }

    void pickup()
    {
        if (Input.GetAxisRaw("Interract") >= .5f)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
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

    void checkDrop()
    {
        if (Input.GetAxisRaw("Interract") <= .5f)
        {
            dropObject();
        }
    }

    void dropObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }
}