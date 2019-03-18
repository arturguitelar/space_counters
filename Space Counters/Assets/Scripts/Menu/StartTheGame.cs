using UnityEngine;
using System.Collections;

public class StartTheGame : MonoBehaviour {

    SceneController scene = new SceneController();
    DifficultGenerator difficult = new DifficultGenerator();

    public void StartGame()
    {
        scene.StartInGame();
    }

    // difficultLevelNumber: 1 - normal / 2 - hard / 3 - insane
    public void ChooseDifficult(int difficultLevel)
    {
        difficult.SetDifficultLevel(difficultLevel);
        StartGame();
    }
}
