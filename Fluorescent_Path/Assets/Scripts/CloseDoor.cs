using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{

    public GameObject player;
    RoomVariables room;
    [SerializeField]
    RoomLoader roomLoader;

    private void Start()
    {
        room = transform.parent.GetComponent<RoomVariables>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<Collider>() == other)
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
