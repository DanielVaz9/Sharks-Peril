using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkFollowPlayer : MonoBehaviour
{
    public GameObject Player;

    public float SharkSpeed, SharkRotationSpeed;

    public bool SharkFollowingPlayer;

    public float Distance;

    // Update is called once per frame
    void Update()
    {
        //Distance between player and shark
        Distance = Vector3.Distance(Player.transform.position, transform.position);
    }


    public void FollowPlayer()
    {
        //"Cooldown" so the shark doesn't glue to the player while walking
        if (!SharkAttack.StopMovingAfterAttack)
        {
            //If the player is in range, start following
            if (Distance < 20)
            {
                //This is to make the function of wandering stop
                SharkFollowingPlayer = true;

                if (CanSeePlayer(Player)) //If the player is on the vision cone, move towards him
                {
                    transform.position += transform.forward * SharkSpeed * Time.deltaTime;
                }
                else
                {
                    //Rotate to the player
                    Quaternion TargetRotation = Quaternion.LookRotation(Player.transform.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, SharkRotationSpeed * Time.deltaTime);
                }
            }

        }
    }


    private bool CanSeePlayer(GameObject gameObject)
    {
        float ViewAngle = 10;
        float SightRange = 20;

        Vector3 Direction = Player.transform.position - transform.position;

        float Angle = Vector3.Angle(transform.forward, Direction);

        RaycastHit Hit;

        //If the player is in the cone of vision of the shark, return true
        if (Angle <= ViewAngle && Physics.Raycast(transform.position, Direction, out Hit, SightRange))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
