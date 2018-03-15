using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MirrorRoom : RoomVariables {

    [SerializeField]
    List<GameObject> tiles = new List<GameObject>();

	// Use this for initialization
	void Start () {     
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FindPLayers()
    {
        foreach (GameObject playa in tiles)
        {
            if(playa.GetComponent<PlayerDetectingTiles>().player != null)
            {

            }

        }
    }
}
