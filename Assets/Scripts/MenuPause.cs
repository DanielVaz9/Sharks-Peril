using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject PauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);

            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
