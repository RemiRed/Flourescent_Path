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

    bool pulled = false;

    [Command]
    void CmdPull()
    {
        print(roomLoader.clearedRoom);
        if (!pulled)
        {
            print("Pulled");
            if (roomLoader.clearedRoom)
            {
                print("Load");
                roomLoader.CmdLoad();
            }
            pulled = true;
            roomLoader.clearedRoom = true;
        }
    }

    [Command]
    void CmdRelease()
    {
        print("Release");
        pulled = false;
        roomLoader.clearedRoom = false;
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(doorDelay);
        exitDoor.SetActive(false);
        yield return null;
    }

}
