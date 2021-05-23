using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public static bool IsOnSurface;

    private void OnTriggerStay(Collider other)
    {
        //Check if the player is colliding
        if(other.gameObject.name == "Player")
        {
            IsOnSurface = true;

            Debug.Log("Entered box");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Check if the player is colliding
        if (other.gameObject.name == "Player")
        {
            IsOnSurface = false;

            Debug.Log("Left");
        }
    }
}
