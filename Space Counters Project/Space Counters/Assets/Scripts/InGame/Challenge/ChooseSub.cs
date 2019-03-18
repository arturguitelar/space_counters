using UnityEngine;
using System.Collections;

public class ChooseSub : IChooseChallenge
{
    public IChallenge ChooseTheChallenge()
    {
        return new ChallengeSub();
    }
}
