using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : Interractable
{

    public GameObject exitDoor;
    public GameObject entryDoor;
    [SerializeField]
    RoomLoader roomLoader;

    [SerializeField]
    float doorDelay;

    bool activated = false;
    public void Press()
    {
        if (activated)
        {
            return;
        }
        transform.localScale = new Vector3(.5f, .3f, .08f);
        StartCoroutine(OpenDoor());
        if (roomLoader != null)
        {
           // roomLoader.CmdLoad();
        }
    }

    void Unload()
    {
        exitDoor.SetActive(true);
        roomLoader.UnloadCorridor();

    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(doorDelay);
        exitDoor.SetActive(false);

        yield return null;
    }
}
