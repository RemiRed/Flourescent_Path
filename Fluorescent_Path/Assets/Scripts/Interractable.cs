using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Interractable : NetworkBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    string interractMethodName,stopInterractMethodName;
    [SerializeField]
    protected float delay;

    public void Interract() //Calls the interractable objects method that happens when it's interracted with after a delay
    {
        Invoke(interractMethodName, delay);
    }

    public void StopInterract()
=======
    string methodName;

	public bool active = true;
    
    public void Interract()
>>>>>>> 55791796289248d34a93fbc06a434f3974eebc34
    {
        if (stopInterractMethodName != null)
        {
            Invoke(stopInterractMethodName, delay);
        }
    }
}
