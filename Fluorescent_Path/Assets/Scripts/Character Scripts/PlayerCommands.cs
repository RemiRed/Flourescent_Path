using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCommands : NetworkBehaviour
{
    [SerializeField]
    RoomLoader roomLoader;

    private void Start()
    {
        roomLoader = GameObject.FindGameObjectWithTag("RoomLoader").GetComponent<RoomLoader>();
    }

    [Command]
    public void CmdCorridorLever()
    {
        if (roomLoader.clearedRoom)
        {
            CmdLoad();
        }
        roomLoader.clearedRoom = true;
    }

    [Command]
    public void CmdLoad() //Loads the next room, or last room if the last room is the next room
    {
        if (roomLoader.nextRoomNumber < roomLoader.numberOfRooms)
        {
            roomLoader.LoadNextRoom();
        }
        else
        {
            roomLoader.LoadFinalRoom();
        }
    }
}
