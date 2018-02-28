using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{

    [SerializeField]
    string methodName;
    [SerializeField]
    protected float delay;

    public void Interract()
    {
        Invoke(methodName, delay);
    }
}
