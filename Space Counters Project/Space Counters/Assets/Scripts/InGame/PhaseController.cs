using UnityEngine;
using System.Collections;

public class PhaseController : MonoBehaviour {
    public int currentPhase;
    public int numberChallengesToIncreaseDifficult;
    public int toNextPhase;
    public string phaseNameTxt;
    public string phaseChallengeTxt;

    public int MultiplierNextPhase()
    {
        DifficultNextPhase difficult = new DifficultNextPhase();
        toNextPhase = difficult.GenerateDifficult(toNextPhase);

        return toNextPhase;
    }
}
