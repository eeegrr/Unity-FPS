using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    Light lightBulb;

    private void Start()
    {
        lightBulb = GetComponent<Light>(); // fetch component

    }


    public void ToggleLamp()
    {
        // if light is not enabled
        if (!lightBulb.enabled)
        {
            lightBulb.enabled = true;
        }
        // otherwise
        else
        {
            lightBulb.enabled = false;
        }



    }


}
