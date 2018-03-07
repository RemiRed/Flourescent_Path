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
    public bool CmdCorridorLever()
    {
        bool tempBool = false;
        if (roomLoader.clearedRoom)
        {
            roomLoader.CmdLoad();
            tempBool = true;
        }
        roomLoader.clearedRoom = true;
        return tempBool;
    }
}
