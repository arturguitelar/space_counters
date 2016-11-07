using UnityEngine;
using System.Collections;

public class SaveGameStatus {

    private const string playerLives = "PlayerLives";
    private const string playerScore = "PlayerScore";
    private const string gameDifficult = "GameDifficult";

    public void SetPlayerLivesToPlayerPrefs (int lives)
    {
        PlayerPrefs.SetInt(playerLives, lives);
    }

    public void SetPlayerScoreToPlayerPrefs(int score)
    {
        PlayerPrefs.SetInt(playerScore, score);
    }

    public void SetGameDifficultToPlayerPrefs(int difficult)
    {
        PlayerPrefs.SetInt(gameDifficult, difficult);
    }

    public int GetPlayerLivesFromPlayerPrefs()
    {
        return PlayerPrefs.GetInt(playerLives);
    }

    public int GetPlayerScoreFromPlayerPrefs()
    {
        return PlayerPrefs.GetInt(playerScore);
    }

    public int GetGameDifficultToPlayerPrefs()
    {
        return PlayerPrefs.GetInt(gameDifficult);
    }

}
