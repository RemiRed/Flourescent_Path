using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    
    RoomVariables room;
    [SerializeField]
    RoomLoader roomLoader;

    private void Start()
    {
        room = transform.parent.GetComponent<RoomVariables>();
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            Unload();
        }
    }

    void Unload()
    {
        room.entryDoor.SetActive(true);
        roomLoader.UnloadCorridor();
        Destroy(gameObject);
    }
}
