using UnityEngine;
using System.Collections;

public class ChallengeSum : IChallenge {

    public ChallengeObj GetChallengeObj(ChallengeController chaController) {

        ChallengeObj obj = new ChallengeObj();

        chaController.UpdateChallenge();

        obj.NumberA = chaController.Number1;
        obj.NumberB = chaController.Number2;
        obj.Signal = "+";
        obj.Result = Calculate(chaController.Number1, chaController.Number2);

        return obj;
    }

    public int Calculate(int a, int b)
    {
        return a + b;
    }
}
