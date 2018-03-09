using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	public const int maxHealth = 100;

	[SyncVar (hook = "OnChangeHealth")]
	public int curHealth = maxHealth;
	public RectTransform healthBar;

	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int _dmg){

		if (!isServer) {
			
			Debug.Log ("Not server");
			return;
		}

		curHealth -= _dmg;
		if (curHealth <= 0) {
			curHealth = 0;
			RpcRespawn ();
			curHealth = maxHealth;
			Debug.Log ("DEAD!");
		}
		Debug.Log ("CurHealth = " + curHealth);
	}

	void OnChangeHealth(int _curhealth){

		healthBar.sizeDelta = new Vector2 (_curhealth, healthBar.sizeDelta.y); 
	}

	[ClientRpc]
	void RpcRespawn(){

		if (isLocalPlayer) {

			transform.position = Vector3.zero;
		}
	}


	void OnDestroy(){

		if (isLocalPlayer) {

			Debug.Log (gameObject.name + " disconnected");
		}
	}
}
