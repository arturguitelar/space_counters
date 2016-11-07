using UnityEngine;
using System.Collections;

public class Restart {
    GameController gameController;
    ChallengeController challenge;
    InGameDisplayText displayText;

    public Restart(GameController gameController, ChallengeController challenge)
    {
        this.gameController = gameController;
        this.challenge = challenge;
    }

    public void GetDisplayTextFromGameController(InGameDisplayText displayText)
    {
        this.displayText = displayText;
    }

    public void RestartGame()
    {
        if (gameController.RestartFlag)
        {
            displayText.SetRestartText(InGameConstantStrings.RESTART);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneController scene = new SceneController();
                challenge.ResetDifficult();
                scene.ResetScene();
            }
        }
    }
}
