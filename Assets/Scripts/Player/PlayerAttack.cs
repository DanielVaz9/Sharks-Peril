using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Camera Camera;

    public GameObject AttackImg;
    public GameObject Knife;

    public Animator Animator;

    public static bool PlayerAttacking;

    private bool ActiveImage;

    private int Count = 0;

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;

        Ray FrontRay = new Ray(transform.position, Vector3.forward);

        //Raycast to the front of the camera
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out Hit, 0.7f))
        {
            if (Hit.collider.tag == "Shark" && Count < 1)
            {
                //Enable the icon to attack
                AttackImg.SetActive(true);

                //Left mouse click input
                if (Input.GetMouseButtonDown(0))
                {
                    //Activate knife in the scene
                    Knife.SetActive(true);

                    //Call function to block the controls
                    BlockControls.Block(true);

                    Count++;

                    //Start the attack cooldown
                    StartCoroutine("AttackCooldown");
                }
            }
        }
        else
        {
            //Disable the icon to attack
            AttackImg.SetActive(false);
        }
    }


    IEnumerator AttackCooldown()
    {
        //Enable the attack icon
        AttackImg.SetActive(false);

        //Wait 1.5 seconds to say that the player is not attacking anymore and start moving freely
        yield return new WaitForSeconds(1.5f);
        
        //Unblock the controls
        BlockControls.Block(false);


        yield return new WaitForSeconds(1.5f);

        //Deactivate knife in the scene
        Knife.SetActive(false);

        //Reset counter to attack again
        Count = 0;
    }
}
