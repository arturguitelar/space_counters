using UnityEngine;
using System.Collections;

public class InGameMenuController : MonoBehaviour
{
    void Start()
    {
        // setting time default (unpaused)
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        ScanForKeyStroke();
    }

    public void BackToMainMenu()
    {
        SceneController scene = new SceneController();
        scene.StartMenu();
    }

    public void BackToGame()
    {
        ToggleInGameMenu();
    }

    public void ExitGame()
    {
        new ExitGame();
    }

    private void ScanForKeyStroke()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ToggleInGameMenu();
    }

    private void ToggleInGameMenu()
    {
        if (GetComponentInChildren<Canvas>().enabled)
        {
            GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }
    }
}
