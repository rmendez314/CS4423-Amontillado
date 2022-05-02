using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame = false;

    public GameObject PauseMenuOp;


    void Update()
    {
        if (PauseGame && PauseMenuOp != null) 
        { 
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true; 
        } 
        else 
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        PauseMenuOp.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause()
    {
        PauseMenuOp.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
