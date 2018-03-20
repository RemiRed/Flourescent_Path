using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MirrorRoom : RoomVariables
{

    [SyncVar]
    public int playerCol, playerRow;


    int col = 3, row = 1;
    bool pathCheck = false;

    public void CreatePath() //kALLA PÅ SKRIPTETE
    {
        if (pathCheck)
        {
            return;
        }
        else
        {
            pathCheck = true;
        }
        while (row <= 17)
        {
            //Open random door in col/row
            foreach (GameObject tile in GameObject.FindGameObjectsWithTag("MirrorRoomTile"))
            {
                if (tile.GetComponent<PlayerDetectingTiles>().CheckRowCol(row, col))
                {
                    int doorID = 0; //slumpa
                    tile.GetComponent<PlayerDetectingTiles>().RemoveWall(doorID);
                    continue;
                }
            }
            //Only allow back if there's a path that's possible to go forward later

        }
        //open doors to exit
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
