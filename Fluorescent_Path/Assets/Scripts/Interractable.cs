using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{
    [SerializeField]
    string methodName;
    
    public void Interract()
    {
        Invoke(methodName, 0);        
    }
}
