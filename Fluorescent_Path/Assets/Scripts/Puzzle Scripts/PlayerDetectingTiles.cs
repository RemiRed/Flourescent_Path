using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectingTiles : MonoBehaviour {

    public GameObject player;
    public int whatTile;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coolDude)
    {
        player = coolDude.gameObject;
    }

    void OnTriggerExit(Collider coolDude)
    {
        player = null;
    }

}
