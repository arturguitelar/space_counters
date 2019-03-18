using UnityEngine;
using System.Collections;

public class ChallengeSub : IChallenge {

    public ChallengeObj GetChallengeObj(ChallengeController chaController)
    {
        ChallengeObj obj = new ChallengeObj();

        chaController.UpdateChallenge();

        obj.Signal = "-";
        obj.Result = VerifyIfSubtractIsValid(chaController);
        obj.NumberA = chaController.Number1;
        obj.NumberB = chaController.Number2;

        return obj;
    }

    public int Calculate(int a, int b)
    {
        return a - b;
    }

    private int VerifyIfSubtractIsValid(ChallengeController chaController)
    {
        int res = chaController.Number1 - chaController.Number2;

        while (VerifyIfResultsIsNegative(res))
        {
            chaController.UpdateChallenge();

            res = chaController.Number1 - chaController.Number2;
        }

        return Calculate(chaController.Number1, chaController.Number2);
    }

    private bool VerifyIfResultsIsNegative(int number)
    {
        // para simplificar a lógica, estou considerando que 0
        // será considerado negativo neste contexto
        if (number > 0)
        {
            return false;
        }

        return true;
    }
}
