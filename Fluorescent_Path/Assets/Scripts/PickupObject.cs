using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    bool carrying = false;
    GameObject carriedObject;
    [SerializeField]
    float carryDistance;
    [SerializeField]
    float carrySpeed;

    bool keyUp = true;
    void Update()
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
            carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, transform.position + transform.forward * carryDistance, Time.deltaTime * carrySpeed);
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

            }
        }
    }

    void Drop()
    {
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().freezeRotation = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.transform.parent = null;
        carriedObject = null;
    }
}