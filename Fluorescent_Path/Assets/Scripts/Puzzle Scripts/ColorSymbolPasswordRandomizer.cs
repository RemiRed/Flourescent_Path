using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ColorSymbolPasswordRandomizer : NetworkBehaviour {

	public Password passwordManager;

	public List<Color> symbolColors;
	public List<GameObject> symbols;

//	public List<Transform> symbolLocations;


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
