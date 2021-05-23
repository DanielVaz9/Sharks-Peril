using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public float PlayerHealth;

    public Slider Slider;

    public GameObject LoseText, Panel;

    // Start is called before the first frame update
    void Start()
    {
        SetHealthBar(PlayerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (AirTank.AirTankEmpty)
        {
            //Player loses health overtime if the air tank is empty
            PlayerHealth -= 5 * Time.deltaTime;

            SetHealthBar(PlayerHealth);
        }

        if (PlayerHealth <= 0)
        {
            //Block mouse and movement
            BlockControls.Block(true);

            //Show panel and lose text
            Panel.SetActive(true);
            LoseText.SetActive(true);

            

            StartCoroutine("PlayerDeath");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shark")
        {
            //Only lose health if the shark is attacking
            if (SharkAttack.IsSharkAttacking)
            {
                PlayerHealth -= 20;

                SetHealthBar(PlayerHealth);
            }
        }
    }


    public void SetHealthBar(float Health)
    {
        //Set the health bar
        Slider.value = Health;
    }

    IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(2);

        //When the player dies, restart the scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        //Unblock movement and mouse
        BlockControls.Block(false);
    }
}
