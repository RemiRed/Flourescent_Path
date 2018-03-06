using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : Interractable
{


    public void Press()
    {
        transform.localScale = new Vector3(.5f, .11f, .5f);

		active = false;
    }
}
