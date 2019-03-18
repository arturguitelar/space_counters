using UnityEngine;
using System.Collections;

public interface IChallenge {
    ChallengeObj GetChallengeObj(ChallengeController chaController);
    int Calculate(int a, int b);
}
