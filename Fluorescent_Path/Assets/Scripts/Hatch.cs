using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    [SerializeField]
    GameObject hatchidessu;

    void Start()
    {

    }


    void OnTriggerEnter(Collider col)
    {
        hatchidessu.GetComponent<Animation>().Play("Hatching");

    }

}
