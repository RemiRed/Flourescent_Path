using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordButton : Interractable {

	public Password passwordManager;
	public int buttonOrderID;
	public bool buttonActive = true;

	void PasswordButtonPressed(){

		if (buttonActive) {

			buttonActive = false;

			passwordManager.CheckPassword (buttonOrderID-1);
		}
	}
}
