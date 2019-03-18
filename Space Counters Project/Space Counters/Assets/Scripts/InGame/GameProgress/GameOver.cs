using UnityEngine;
using System.Collections;

public class GameOver {

    public GameOver(InGameDisplayText displayText, GameController gameController)
    {
        gameController.RestartFlag = true;
        gameController.ContinueSpawnWaves = false;

        displayText.SetChallengeText("");
        displayText.SetChallengeAlertText("");

        displayText.SetGameOverText(InGameConstantStrings.GAME_OVER);
    }
}
