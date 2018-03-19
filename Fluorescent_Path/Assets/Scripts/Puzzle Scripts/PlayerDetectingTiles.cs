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
    List<GameObject> walls = new List<GameObject>();

    private void Start()
    {
        Quaternion rotate = new Quaternion();
        rotate.eulerAngles = new Vector3(0, 90, 0);
        walls.Add(Instantiate(wall, transform.position + new Vector3(-2.75f, 1.9f, 0), rotate));
        walls.Add(Instantiate(wall, transform.position + new Vector3(0, 1.9f, -2.75f), new Quaternion()));
        //CreatePath();
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
