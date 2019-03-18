using UnityEngine;
using System.Collections;

public class ChooseMult : IChooseChallenge
{
    public IChallenge ChooseTheChallenge()
    {
        return new ChallengeMult();
    }
}
