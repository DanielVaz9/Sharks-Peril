using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterFX : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (WaterTrigger.IsOnSurface)
        {
            //Turn the fog off if the player is on the surface of the water
            RenderSettings.fog = false;
        }
        else
        {
            //Change colour and density of the fog
            RenderSettings.fogColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
            RenderSettings.fogDensity = 0.02f;
            RenderSettings.fog = true;
        }
    }
}
