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
        print(roomLoader.gameObject.name);
        if (roomLoader.clearedRoom)
        {
            roomLoader.CmdLoad();
        }
        roomLoader.clearedRoom = true;
    }
}
