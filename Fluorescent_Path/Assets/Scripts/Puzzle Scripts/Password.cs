using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password : MonoBehaviour {

	public PasswordButton[] passwordButtons;

	public int nextID, passwordLock;
		
	public void CheckPassword(int _ID){

		if (_ID == nextID) {

			nextID++;
			passwordLock++;

			if (passwordLock == passwordButtons.Length) {

						Debug.Log ("CORRECT PASSWORD!");
			}
				
		} else {

			for (int i = 0; i < passwordButtons.Length; i++) {

				passwordButtons [i].buttonActive = true;
			}
			nextID = 0;
			passwordLock = 0;
		}
	}

	void RandomizePAssword(){



	}
}
