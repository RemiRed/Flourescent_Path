using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : Interractable {
   
    bool LeverPulled = false;
    Animator anim1;
    Animator anim2;


    void Start()
    {
        anim1 = GetComponent<Animator>();
        anim2 = GetComponent<Animator>();
    }

    void Pulling()
    {

        if (LeverPulled == false)
        if (Input.GetKeyDown(KeyCode.E))
            {
                LeverPulled = true;
                Debug.Log("Unlocked a map");
                anim1.Play("Pulling");
                anim2.Play("Temporary");
            
            }  
    }

}
