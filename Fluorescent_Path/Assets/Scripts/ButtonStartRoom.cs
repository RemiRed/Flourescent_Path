using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonStartRoom : Interractable
{
    [SerializeField]
    GameObject startRoomDoor;

    [SerializeField]
    RoomLoader roomLoader;

    [SerializeField]
    float doorDelay;

    bool activated = false;

    [SyncVar(hook = "Test")]
    bool testing = false;

    void Press()
    {
        if (activated)
        {
            return;
        }
        activated = true;
        StartCoroutine(OpenDoor());
        CmdPress();
    }

    [Command]
    void CmdPress()
    {
        testing = true;
    }

    void Test(bool testing)
    {
        print(testing);
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(doorDelay);
        startRoomDoor.SetActive(false);
        yield return null;
    }

}
