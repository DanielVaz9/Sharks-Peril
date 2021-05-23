using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseMovement : MonoBehaviour
{
    public float Sensitivity = 1;

    float MouseX, MouseY;
    float RotateX = 0, RotateY;

    public GameObject Player;

    Vector2 CamSmoothing;
    public float SmoothCamValue;

    void Start()
    {
        //Make the cursor disappear
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        //Only move the cursor if the player is not blocked from doing so
        if (!BlockControls.blockcontrols)
        {
            //Inputs
            MouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
            MouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

            //To make the camera rotate smoothly, without breaks
            CamSmoothing.x = Mathf.Lerp(CamSmoothing.x, MouseX, 1f / SmoothCamValue);
            CamSmoothing.y = Mathf.Lerp(CamSmoothing.y, MouseY, 1f / SmoothCamValue);

            //Set the variable to rotate and lock the rotation between -90 and 90 degrees
            RotateX -= CamSmoothing.y;
            RotateX = Mathf.Clamp(RotateX, -90f, 90f);

            //RotateY -= CamSmoothing.x;

            //Rotate the X and Y axis of the player object and the camera
            Player.transform.Rotate(Vector3.up * CamSmoothing.x);
            transform.localRotation = Quaternion.Euler(RotateX, 0f, 0f);


            ////If the escape key is pressed, show the cursor
            //if (Input.GetKeyDown("escape"))
            //{
            //    Cursor.lockState = CursorLockMode.None;
            //}
        }

    }
}
