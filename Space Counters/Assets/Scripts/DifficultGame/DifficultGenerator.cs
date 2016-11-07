using UnityEngine;
using System.Collections;

public class DifficultGenerator {

    // difficultLevel: 1 - normal / 2 - hard / 3 - insane
    SaveGameStatus gameStatus = new SaveGameStatus();

    public void SetDifficultLevel(int difficultLevel)
    {
        gameStatus.SetGameDifficultToPlayerPrefs(difficultLevel);
    }

    public int GetDifficultLevel()
    {
        return gameStatus.GetGameDifficultToPlayerPrefs();
    }
}
