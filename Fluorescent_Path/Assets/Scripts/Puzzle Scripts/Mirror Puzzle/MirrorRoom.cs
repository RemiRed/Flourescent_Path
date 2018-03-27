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

    [SerializeField]
    GameObject[,] tiles = new GameObject[20, 7];

    List<int> lastThreeIDs = new List<int>();

    private void Start()
    {
        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("MirrorRoomTile"))
        {
            tiles[tile.GetComponent<PlayerDetectingTiles>().row, tile.GetComponent<PlayerDetectingTiles>().col] = tile;
        }
    }

    void Update()
    {
        if (!pathCheck)
        {
            CreatePath();
        }
        //CheckIfSameTile();
    }


    public void CreatePath()
    {

        int doorID = 1;
        List<int> allowedDoorIDs = new List<int>();
        if (row != 18)
        {
            allowedDoorIDs.Add(0);
            allowedDoorIDs.Add(1);
            allowedDoorIDs.Add(2);
        }
        else if (col < 3)
        {
            allowedDoorIDs.Add(0);
        }
        else
        {
            allowedDoorIDs.Add(1);
        }

        if (row != 18 && lastThreeIDs.Count >= 3)
        {
            if (lastThreeIDs[0] == lastThreeIDs[1] && lastThreeIDs[0] == lastThreeIDs[2])
            {
                allowedDoorIDs.Remove(lastThreeIDs[0]);
            }
        }



        bool tempCheck = true;
        while (tempCheck)
        {
            doorID = allowedDoorIDs[Random.Range(0, allowedDoorIDs.Count)];
            tempCheck = !tiles[row, col].GetComponent<PlayerDetectingTiles>().RemoveWall(doorID);
        }

        lastThreeIDs.Add(doorID);
        if (lastThreeIDs.Count > 3)
        {
            lastThreeIDs.RemoveAt(0);
        }
        if (doorID == 0)
        {
            col++;
        }
        else if (doorID == 1)
        {
            col--;
        }
        else if (doorID == 2)
        {
            row++;
        }
        else if (doorID == 3)
        {
            row--;
        }
        if (row == 18 && col == 3)
        {

            pathCheck = true;
        }

        //Only allow back if there's a path that's possible to go forward later

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
