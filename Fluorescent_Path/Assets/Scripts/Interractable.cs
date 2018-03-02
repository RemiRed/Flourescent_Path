using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{
    [SerializeField]
    string methodName;
    [SerializeField]
    protected float delay;

    public void Interract() //Calls the interractable objects method that happens when it's interracted with after a delay
    {
        Invoke(methodName, delay);
    }
}
