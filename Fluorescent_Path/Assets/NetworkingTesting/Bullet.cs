using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {

	public int damage = 10;


	void Start(){

		Debug.Log ("Bullet in the air");
	}




	void OnCollisonEnter(){

		Debug.Log ("Hit other player");
//
//		if (other.transform.tag == "Player") {
//			other.transform.GetComponent<Health> ().TakeDamage (damage);
//		}

		Destroy (gameObject);
	}
}
