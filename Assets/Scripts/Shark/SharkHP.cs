using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SharkHP : MonoBehaviour
{
    public int SharkHealth;

    public GameObject Shark;

    private Animator Animator;

    public GameObject WinText, Panel;

    public static bool SharkDead;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (SharkHealth <= 0)
        {
            SharkDead = true;

            //Shark's death animation
            Animator.Play("SharkDeath");

            //Show win text
            Panel.SetActive(true);
            WinText.SetActive(true);

            StartCoroutine("WaitForAnimation");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the knife collides with the shark and checks if the player is attacking
        //to prevent the shark from losing health while the knife is still active
        if (collision.collider.name == "Knife" && BlockControls.blockcontrols)
        {
            SharkHealth -= 10;
        }
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(4);

        //When the player dies, restart the scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}