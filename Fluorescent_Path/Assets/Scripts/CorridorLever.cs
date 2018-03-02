﻿using System.Collections;
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
    void Pull()
    {
        if (!pulled)
        {
            if (roomLoader.clearedRoom)
            {
                roomLoader.Load();
            }
            pulled = true;
            roomLoader.clearedRoom = true;
        }
    }
    
    void Release()
    {
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
