using UnityEngine;
using System.Collections;

public class BackToMainMenu : MonoBehaviour {
    public void BackToMenu()
    {
        new SceneController().StartMenu();
    }
}
