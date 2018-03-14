using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainIgnore : MonoBehaviour {

    [SerializeField]
    GameObject hedges;
	// Use this for initialization
	void Start () {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), hedges.GetComponentInChildren<Collider>());	
	}
	

}
