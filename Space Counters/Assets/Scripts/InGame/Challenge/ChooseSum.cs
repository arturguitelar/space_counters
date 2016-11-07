using UnityEngine;
using System.Collections;

public class ChooseSum : IChooseChallenge {
    public IChallenge ChooseTheChallenge()
    {
        return new ChallengeSum();
    }
}
