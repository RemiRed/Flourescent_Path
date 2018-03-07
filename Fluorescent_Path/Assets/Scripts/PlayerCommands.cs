using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCommands : NetworkBehaviour
{

    private void Start()
    {
        roomLoader = GameObject.FindGameObjectWithTag("RoomLoader").GetComponent<RoomLoader>();
    }

    [SerializeField]
    RoomLoader roomLoader;

    [SyncVar(hook = "TestHook")]
    string test;

    [Command]
    public void CmdTest()
    {
        test = "Hej!";
    }

    void TestHook(string test)
    {
        print(test);
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
