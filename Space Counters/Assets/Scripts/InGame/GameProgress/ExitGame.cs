using UnityEngine;
using System.Collections;

public class ExitGame {
    public ExitGame()
    {
        SceneController scene = new SceneController();
        scene.ExitGame();
        Debug.Log("exit");
    }
}
