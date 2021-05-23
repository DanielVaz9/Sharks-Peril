using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkCollisionWithEnvironment : MonoBehaviour
{
    public GameObject Player;

    public static bool ChangeRotation;

    private void OnCollisionEnter(Collision collision)
    {
        //If the player collides with a wall, change the direction
        if(collision.collider.tag == "Wall")
        {
            ChangeRotation = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ChangeRotation = false;
    }
}