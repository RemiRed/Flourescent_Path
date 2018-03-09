using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {

	public int damage = 10;

	void OnCollisionEnter(Collision _other){

		if (_other.transform.tag == "Player") {
			_other.transform.GetComponent<Health> ().TakeDamage (damage);
		}

		Destroy (gameObject);
	}

	void OnDestroy(){

		//GameObject.FindGameObjectWithTag ("Player").transform.position = transform.position;

	}
}
