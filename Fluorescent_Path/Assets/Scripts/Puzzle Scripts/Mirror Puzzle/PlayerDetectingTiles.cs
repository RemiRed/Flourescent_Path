using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerDetectingTiles : NetworkBehaviour
{
    [SerializeField]
    GameObject room;
    GameObject player;
    [SerializeField]
    int row, col;

    [SerializeField]
    GameObject wall;

    [SerializeField]
    GameObject[] walls = new GameObject[4];


    private void Start()
    {
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("MirrorRoomWall"))
        {

            if (wall.transform.position.x > transform.position.x && wall.transform.position.z == transform.position.z)
            {
                if (walls[0] != null)
                {
                    if (wall.transform.position.x < walls[0].transform.position.x)
                    {
                        walls[0] = wall;
                    }
                }
                else
                {
                    walls[0] = wall;
                }
            }

            if (wall.transform.position.x < transform.position.x && wall.transform.position.z == transform.position.z)
            {
                if (walls[1] != null)
                {
                    if (wall.transform.position.x > walls[1].transform.position.x)
                    {
                        walls[1] = wall;
                    }
                }
                else
                {
                    walls[1] = wall;
                }
            }

            if (wall.transform.position.x == transform.position.x && wall.transform.position.z > transform.position.z)
            {
                if (walls[2] != null)
                {
                    if (wall.transform.position.z < walls[2].transform.position.z)
                    {
                        walls[2] = wall;
                    }
                }
                else
                {
                    walls[2] = wall;
                }
            }

            if (wall.transform.position.x == transform.position.x && wall.transform.position.z < transform.position.z)
            {
                if (walls[3] != null)
                {
                    if (wall.transform.position.z > walls[3].transform.position.z)
                    {
                        walls[3] = wall;
                    }
                }
                else
                {
                    walls[3] = wall;
                }
            }
        }
    }

    void OnTriggerEnter(Collider playerCollider)
    {
        player = playerCollider.gameObject;
        player.GetComponent<PlayerCommands>().CmdUppdatePosition();
        room.GetComponent<MirrorRoom>().playerCol = col;
        room.GetComponent<MirrorRoom>().playerRow = row;
    }

    void OnTriggerExit(Collider coolDude)
    {
        player = null;
    }

    public void RemoveWall(int wallID)
    {
        walls[wallID].SetActive(false);
    }

    bool PossiblePath()
    {
        return true;
    }
}
