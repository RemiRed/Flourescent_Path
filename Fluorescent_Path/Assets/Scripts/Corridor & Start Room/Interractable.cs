using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Interractable : NetworkBehaviour
{
    [SerializeField]
    string interractMethodName, stopInterractMethodName;
    [SerializeField]
    protected float delay;

    public PlayerCommands playerCmd;

    public void Interract() //Calls the interractable objects method that happens when it's interracted with after a delay
    {
        Invoke(interractMethodName, delay);
    }

    public void StopInterract()
    {
        print("innan");
        if (stopInterractMethodName != null && stopInterractMethodName != "")
        {
            print(true);
            Invoke(stopInterractMethodName, delay);
        }
    }
}
