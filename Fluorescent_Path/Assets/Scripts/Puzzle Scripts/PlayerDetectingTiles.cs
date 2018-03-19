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

    }

    bool PossiblePath()
    {
        return true;
    }
}
