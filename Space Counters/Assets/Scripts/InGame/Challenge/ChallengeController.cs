using UnityEngine;
using System.Collections;

public class ChallengeController : MonoBehaviour
{ 

    private IChallenge calc;

    public int Number1 { get; set; }
    public int Number2 { get; set; }

    private int difficultStart = 1;
    private int difficultEnd = 21;

    private ChallengeType challengeType;

    public ChallengeObj GetChallenge(IChooseChallenge challengeType)
    {
        calc = challengeType.ChooseTheChallenge();
        return calc.GetChallengeObj(this);
    }

    public void UpdateChallenge()
    {
        Number1 = RandomNumbers();
        Number2 = RandomNumbers();
    }

    public void IncreaseDifficult()
    {
        difficultStart += 10;
        difficultEnd += 20;
    }

    public void ResetDifficult()
    {
        difficultStart = 1;
        difficultEnd = 21;
    }

    public void SetChallengeType(int currentPhase)
    {
        challengeType = new ChallengeType();
        challengeType.SetChallengeType(currentPhase);
    }

    public IChooseChallenge GetChallengeType()
    {
        return challengeType.GetChallengeType();
    }

    private int RandomNumbers()
    {
        return Random.Range(difficultStart, difficultEnd);
    }
}
