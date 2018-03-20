using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ColorSymbolPasswordRandomizer : NetworkBehaviour {

	public Password passwordManager;

	public List<Transform> symbolLocations;
	public List<Color> symbolColors;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[ClientRpc]
	void RpcSetRandomPAssword(){



	}
}
