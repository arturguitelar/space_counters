using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartPhase
{
    private InGameDisplayText displayText;
    private PhaseController phase;
    private PlayerController player;

    public void GetDisplayTextFromGameController(InGameDisplayText displayText)
    {
        this.displayText = displayText;
    }

    public void GetThePhaseFromGameController(PhaseController phase)
    {
        this.phase = phase;
    }

    public void GetThePlayerFromGameController(PlayerController player)
    {
        this.player = player;
    }

    public IEnumerator StartTheGame(GameController gameController)
    {
        displayText.SetRestartText("");
        displayText.SetGameOverText("");
        displayText.SetChallengeAlertText("");

        yield return new WaitForSeconds(1f);
        displayText.SetGameOverText(phase.phaseNameTxt);
        yield return new WaitForSeconds(2f);

        displayText.SetGameOverText(phase.phaseChallengeTxt);
        yield return new WaitForSeconds(2f);

        yield return new WaitForSeconds(2f);
        displayText.SetChallengeAlertTextColor(0f, 1f, 0f, 1f);
        displayText.SetChallengeAlertText(InGameConstantStrings.READY);

        yield return new WaitForSeconds(1f);
        displayText.SetChallengeAlertText(InGameConstantStrings.GO);
        displayText.SetGameOverText("");

        yield return new WaitForSeconds(1f);
        gameController.UpdateChallenge();
        player.PlayerAwake();
    }
}
