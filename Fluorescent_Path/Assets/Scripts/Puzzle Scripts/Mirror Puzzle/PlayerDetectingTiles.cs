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
    GameObject[] walls = new GameObject[4]();


    private void Start()
    {
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("MirrorRoomWalls"))
        {
           
            if (wall.transform.position.x > transform.position.x && wall.transform.position.y == transform.position.y)
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

            if (wall.transform.position.x < transform.position.x && wall.transform.position.y == transform.position.y)
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

            if (wall.transform.position.x == transform.position.x && wall.transform.position.y > transform.position.y)
            {
                if (walls[2] != null)
                {
                    if (wall.transform.position.y < walls[2].transform.position.y)
                    {
                        walls[2] = wall;
                    }
                }
                else
                {
                    walls[2] = wall;
                }
            }

            if (wall.transform.position.x == transform.position.x && wall.transform.position.y < transform.position.y)
            {
                if (walls[3] != null)
                {
                    if (wall.transform.position.y > walls[3].transform.position.y)
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

    public void CreatePath()
    {
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
        walls.Clear();
    }

    bool PossiblePath()
    {
        return true;
    }
}
