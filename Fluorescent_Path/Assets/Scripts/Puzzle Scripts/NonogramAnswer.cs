using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonogramAnswer : MonoBehaviour
{
    public static int count;
    [SerializeField]
    RoomLoader roomLoader;

    public GameObject exitDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Movable")
        {
            count++;
        }   
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Movable")
        {
            count--;
        }
    }

    void Update()
    {
        if (count == 5 && roomLoader != null)
        {
            exitDoor.SetActive(false);
           // roomLoader.CmdLoad();
            count = -10;
        }
    }
}
