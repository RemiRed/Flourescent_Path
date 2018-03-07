using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCommands : NetworkBehaviour
{

    [Command]
    public void CmdTest()
    {
        print("Hej!");
    }
}
