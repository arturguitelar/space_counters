using UnityEngine;
using System.Collections;

public class InGameDisplayText : MonoBehaviour
{

    public GUIText scoreText, challengeText, challengeAlertText, 
        livesText, restartText, gameOverText, nextPhaseText;

    public void SetScoreText(string scoreValue)
    {
        scoreText.text = scoreValue;
    }

    public void SetLiveText(string lives)
    {
        livesText.text = lives;
    }

    public void SetChallengeText(string text)
    {
        challengeText.text = text;
    }

    public void SetChallengeAlertText(string text)
    {
        challengeAlertText.text = text;
    }

    public void SetChallengeAlertTextColor(float r, float g, float b, float a)
    {
        challengeAlertText.color = new Color(r, g, b, a);
    }

    public void SetRestartText(string text)
    {
        restartText.text = text;
    }

    public void SetGameOverText(string text)
    {
        gameOverText.text = text;
    }

    public void SetNextPhaseText(string text)
    {
        nextPhaseText.text = text;
    }
}
