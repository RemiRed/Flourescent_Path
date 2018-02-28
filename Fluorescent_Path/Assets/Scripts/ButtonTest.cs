using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : Interractable
{

    public GameObject door;
    public GameObject otherDoor;
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
            otherDoor.SetActive(true);
            roomLoader.Load();
        }
    }

    void Unload()
    {
        door.SetActive(true);
        roomLoader.UnloadCorridor();

    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(doorDelay);
        door.SetActive(false);

        yield return null;
    }
}
