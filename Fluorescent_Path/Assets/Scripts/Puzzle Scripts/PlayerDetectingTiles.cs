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
    List<GameObject> walls = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("MirrorRoomWall"))
        {
            if (wall.transform.position.x + 2.75 == transform.position.x && wall.transform.position.z == transform.position.z)
            {
                walls.Add(wall);
            }
            else if (wall.transform.position.x - 2.75 == transform.position.x && wall.transform.position.z == transform.position.z)
            {
                walls.Add(wall);
            }
            else if (wall.transform.position.x == transform.position.x && wall.transform.position.z + 2.75 == transform.position.z)
            {
                walls.Add(wall);
            }
            else if (wall.transform.position.x == transform.position.x && wall.transform.position.z - 2.75 == transform.position.z)
            {
                walls.Add(wall);
            }

            if (walls.Count >= 4)
            {
                continue;
            }
        }
        CreatePath();
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
