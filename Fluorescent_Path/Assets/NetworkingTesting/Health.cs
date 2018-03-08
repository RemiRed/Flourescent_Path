using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public const int maxHealth = 100;

	public int curHealth = maxHealth;
	public RectTransform healthBar;


	// Use this for initialization
	void Start () {

	//	curHealth = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int _dmg){

		curHealth -= _dmg;
		if (curHealth <= 0) {
			curHealth = 0;
			Debug.Log ("DEAD!");
		}
			
		Debug.Log ("CurHealth = " + curHealth);

		healthBar.sizeDelta = new Vector2 (curHealth, healthBar.sizeDelta.y); 


	}
}
