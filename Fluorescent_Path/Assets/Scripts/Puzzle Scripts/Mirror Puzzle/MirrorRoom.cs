using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MirrorRoom : RoomVariables
{

    [SyncVar]
    public int playerCol, playerRow;
    

    int col = 3, row = 1;

    void Start()
    {

    }

    void Update()
    {
        CheckIfSameTile();
    }

    void CheckIfSameTile()
    {
        if (pairedRoom.GetComponent<MirrorRoom>().playerCol == playerCol && pairedRoom.GetComponent<MirrorRoom>().playerRow == playerRow)
        {
            Debug.Log("is nice");
        }
        else
        {
            Debug.Log("is not nice");
        }
    }



}
