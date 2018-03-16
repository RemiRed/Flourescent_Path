using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerDetectingTiles : NetworkBehaviour {
    [SerializeField]
    GameObject room;
    GameObject player;
    [SerializeField]
    int whatTile;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    [Command]
    public void CmdTriggerEnter()
    {
        room.GetComponent<MirrorRoom>().sameTile = whatTile;
    }

    [Command]
    public void CmdTriggerExit()
    {
        player = null;
    }

    void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
        CmdTriggerEnter();
    }

    void OnTriggerExit(Collider other)
    {
        CmdTriggerExit();
    }

    /*void OnTriggerEnter(Collider coolDude)
    {
        player = coolDude.gameObject;
        room.GetComponent<MirrorRoom>().sameTile = whatTile;
    }
    
    void OnTriggerExit(Collider coolDude)
    {
        player = null;
    }*/
}
