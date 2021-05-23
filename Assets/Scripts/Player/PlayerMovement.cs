using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float X, Z;

    public float WaterDrag, Speed, Buoyancy;

    public Rigidbody RigidBody;
    Vector3 MovePlayer;


    private float Surface = -0.5f;
    private float MaxValue = 2f;


    private void Update()
    {
        //Inputs
        MovePlayer.x = Input.GetAxis("Horizontal");
        MovePlayer.z = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        //Only move and apply forces if the player can move
        if (!BlockControls.blockcontrols)
        {
            Movement();
            Drag();

            //Apply buoyancy and turn on gravity if the player is on the surface
            if (WaterTrigger.IsOnSurface)
            {
                ApplyBuoyancy();
                RigidBody.useGravity = true;
            }
            else //Turn off gravity and stop applying buoyancy if the player is not on the surface
            {
                RigidBody.useGravity = false;
            }
        }
    }

    private void ApplyBuoyancy()
    {
        //Add buoyancy force when the player reaches a y position of 0
        if (transform.position.y < 0f)
        {
            //Clamp the value so the player goes back and forth and doesn't fly
            float BuoyancyForce = Mathf.Clamp01(-transform.position.y / Surface) * MaxValue;
            RigidBody.AddForce(new Vector3(0, Mathf.Abs(Physics.gravity.y) * MaxValue, 0), ForceMode.Acceleration);
        }
    }

    private void Drag()
    {
        //Drag force
        RigidBody.AddForce(RigidBody.velocity * -1 * WaterDrag);
    }

    private void Movement()
    {
        //Player movement
        Vector3 move = Camera.main.transform.right * MovePlayer.x + Camera.main.transform.forward * MovePlayer.z;

        RigidBody.AddForce(move * Speed);


        //Block the spacebar so the player doesn't notice the character going up and down when on the surface
        if (!RigidBody.useGravity)
        {
            //Swim up
            if (Input.GetKey(KeyCode.Space))
            {
                RigidBody.AddForce(new Vector3(0, Speed, 0));
            }
        }
        else
        {
            //Make the player go to 0 on the y axis
            if (RigidBody.transform.position.y > 0)
            {
                RigidBody.position = new Vector3(RigidBody.position.x, 0f, RigidBody.position.z);
            }
        }

        //Swim down
        if (Input.GetKey(KeyCode.C))
        {
            RigidBody.AddForce(new Vector3(0, -Speed, 0));
        }
    }
}