using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{

    [SerializeField]
    string methodName;

	public bool active = true;
    
    public void Interract()
    {
        Invoke(methodName, 0);        
    }
}