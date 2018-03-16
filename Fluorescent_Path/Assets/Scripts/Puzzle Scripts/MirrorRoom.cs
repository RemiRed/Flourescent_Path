using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MirrorRoom : RoomVariables {

    [SyncVar(hook = "Test")]
    public int sameTile;

	// Use this for initialization
	void Start () {     
        
	}
	
	// Update is called once per frame
	void Update () {
        CheckIfSameTile();
	}
    
    void CheckIfSameTile()
    {
        if(pairedRoom.GetComponent<MirrorRoom>().sameTile == sameTile)
        {
            Debug.Log("is nice");
        }
        else
        {
            Debug.Log("is not nice");
        }
    }

    void Test(int tile)
    {
        print(tile);
    }

}
