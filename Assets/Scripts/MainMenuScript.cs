using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        Application.LoadLevel(1);
    }
}
