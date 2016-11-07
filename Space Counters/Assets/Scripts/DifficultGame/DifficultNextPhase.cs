using UnityEngine;
using System.Collections;

public class DifficultNextPhase : DifficultGenerator {
    public int GenerateDifficult(int toNextPhase)
    {
        int difficult = GetDifficultLevel();

        switch (difficult)
        {
            case 1:
                toNextPhase *= 1;
                break;

            case 2:
                toNextPhase *= 2;
                break;

            case 3:
                toNextPhase *= 3;
                break;
        }

        return toNextPhase;
    }
}
