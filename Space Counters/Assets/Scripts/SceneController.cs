using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController {
    private int currentScene;

    public void SetCurrentScene(int currentScene)
    {
        this.currentScene = currentScene;
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(SceneNameConstantStrings.STARTMENU);
    }

    public void StartInGame()
    {
        SceneManager.LoadScene(SceneNameConstantStrings.PHASE_1);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToNextPhase()
    {
        NextPhase();
    }

    private void NextPhase()
    {
        switch(currentScene)
        {
            case 0:
                SceneManager.LoadScene(SceneNameConstantStrings.PHASE_1);
                break;

            case 1 :
                SceneManager.LoadScene(SceneNameConstantStrings.PHASE_2);
                break;

            case 2:
                SceneManager.LoadScene(SceneNameConstantStrings.PHASE_3);
                break;

            case 3:
                SceneManager.LoadScene(SceneNameConstantStrings.PHASE_4);
                break;

            case 4:
                SceneManager.LoadScene(SceneNameConstantStrings.PHASE_5);
                break;

            case 5:
                SceneManager.LoadScene(SceneNameConstantStrings.PHASE_6);
                break;

            case 6:
                SceneManager.LoadScene(SceneNameConstantStrings.PHASE_7);
                break;

            case 7:
                SceneManager.LoadScene(SceneNameConstantStrings.ENDGAME);
                break;
        }
    }
}
