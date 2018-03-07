using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartRoom : Interractable
{
    [SerializeField]
    GameObject startRoomDoor;

    [SerializeField]
    RoomLoader roomLoader;

    [SerializeField]
    float doorDelay;

    bool activated = false;
    void Press()
    {
        if (activated)
        {
            return;
        }
        activated = true;
        StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(doorDelay);
        startRoomDoor.SetActive(false);
        yield return null;
    }

}
