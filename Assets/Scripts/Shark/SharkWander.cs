using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkWander : MonoBehaviour
{
    public float WanderTime;
    public float MoveSpeed;

    public GameObject WaterSurface;

    private int Count;

    Quaternion TargetRotation;

    public void Move()
    {
        if (!SharkHP.SharkDead)
        {
            if (WanderTime > 0) //If the wander time is greater than 0, keep moving to the same direction
            {
                //Move shark
                transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

                WanderTime -= Time.deltaTime;

                //Check collision with walls
                Collision();
            }
            else
            {
                //Random time to wander around
                WanderTime = Random.Range(5f, 10f);

                Wander(); //Change direction to move
            }

        }
    }


    //When the shark collides with the environment
    private void Collision()
    {
        if (SharkCollisionWithEnvironment.ChangeRotation) //If the shark collides with a wall
        {
            if (Count == 0)
            {
                Count++;

                //Rotate 180 on the Y axis
                ChangeDirection();
            }
        }
        else
        {
            //Rotate
            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, 0.2f * Time.deltaTime);
        }

        //Distance between shark and surface
        float SurfaceDistance = WaterSurface.transform.position.y - transform.position.y;

        if (SurfaceDistance < 10)
        {
            //Change direction to move
            TargetRotation = Quaternion.Euler(transform.rotation.x + 90, transform.rotation.y - 180, 0);

            //Debug.Log("Too close to the surface");
        }
    }


    //Change direction to move randomly
    private void Wander()
    {
        //Somewhat random rotation
        TargetRotation = Quaternion.Euler(Random.Range(-90, 90), Random.Range(0, 360), 0);

        #region Commented code
        //Debug.Log("Changed direction");

        //More "controlled" rotation
        //TargetRotation = Quaternion.Euler(Random.Range(transform.rotation.x - 45, transform.rotation.x + 45), Random.Range(transform.rotation.x - 90, transform.rotation.x + 90), 0);


        //Full random rotation
        //TargetRotation = Random.rotation;

        #endregion
    }


    IEnumerator ResetCount()
    {
        if (SharkCollisionWithEnvironment.ChangeRotation)
        {
            yield return new WaitForSeconds(2);

            Count = 0;
        }
    }


    //Make the shark rotate 180 degrees when collision with a wall occurs
    private void ChangeDirection()
    {
        #region Commented code
        //Wander();

        //transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        //Quaternion CurrSharkRotation = Quaternion.Euler(transform.rotation.eulerAngles);

        //CurrSharkRotation.y *= -1;

        //TargetRotation = Quaternion.Euler(0, 180, 0);

        //transform.eulerAngles = new Vector3(0, 180, 0);


        //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180, 0);
        #endregion

        //Rotate 180 degrees
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180, 0);

        //Change direction to move
        TargetRotation = Quaternion.Euler(0, transform.rotation.y - 180, 0);

        StartCoroutine("ResetCount");
    }
}
