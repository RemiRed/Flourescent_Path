using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCommands : NetworkBehaviour
{
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
}
