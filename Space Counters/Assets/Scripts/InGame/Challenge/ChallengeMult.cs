using UnityEngine;
using System.Collections;

public class ChallengeMult : IChallenge {

    private ChallengeObj obj;

    public ChallengeObj GetChallengeObj(ChallengeController chaController)
    {
        ChallengeObj obj = new ChallengeObj();

        chaController.UpdateChallenge();

        obj.NumberA = chaController.Number1;
        obj.NumberB = chaController.Number2;
        obj.Signal = "x";
        obj.Result = Calculate(chaController.Number1, chaController.Number2);

        return obj;
    }

    public int Calculate(int a, int b)
    {
        return a * b;
    }
}
