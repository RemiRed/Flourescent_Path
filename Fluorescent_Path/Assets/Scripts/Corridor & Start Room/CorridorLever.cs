using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CorridorLever : Interractable
{

    public GameObject exitDoor;
    public GameObject entryDoor;
    [SerializeField]
    RoomLoader roomLoader;

    [SerializeField]
    float doorDelay;

    [SerializeField]
    float leverDelay;

    bool pulled = false, opening = false;

    void Pull()
    {
        if (!pulled)
        {
            pulled = true;
            playerCmd.CmdCorridorLever();
            
        }
        if (roomLoader.clearedRoom && !opening)
        {
            opening = true;
            StartCoroutine(OpenDoor());
        }
    }

    void Release()
    {

    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(doorDelay);
        exitDoor.SetActive(false);
        entryDoor.SetActive(true);
        yield return null;
    }

}
