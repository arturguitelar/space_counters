using UnityEngine;
using System.Collections;

public class ChallengeType {

    private int currentPhase;
    private IChooseChallenge currentChallenge;

    public void SetChallengeType(int currentPhase)
    {
        this.currentPhase = currentPhase;
    }

    public IChooseChallenge GetChallengeType()
    {
        ProcessChallenge();
        return currentChallenge;
    }

    private void ProcessChallenge()
    {
        // currentPhase = 1 (recebeu fase 1). E assim por diante.
        switch(currentPhase)
        {
            case 1 : currentChallenge = new ChooseSum();
                break;

            case 2:
                currentChallenge = new ChooseSub();
                break;

            case 3:
                currentChallenge = new ChooseMult();
                break;

            case 4:
                RandomTwoChallengeObjects(new ChooseSum(), new ChooseSub());
                break;

            case 5:
                RandomTwoChallengeObjects(new ChooseSum(), new ChooseMult());
                break;

            case 6:
                RandomTwoChallengeObjects(new ChooseSub(), new ChooseMult());
                break;

            case 7:
                RandomThreeChallengeObjects(new ChooseSum(), new ChooseSub(), new ChooseMult());
                break;
        }
        
    }

    private void RandomTwoChallengeObjects(IChooseChallenge objA, IChooseChallenge objB)
    {
        int result = RandomChallenge(1, 11);

        if (result <= 5)
            currentChallenge = objA;
        else
            currentChallenge = objB;
    }

    private void RandomThreeChallengeObjects(IChooseChallenge objA, 
        IChooseChallenge objB, IChooseChallenge objC)
    {
        int result = RandomChallenge(1, 21);

        if (result <= 5)
            currentChallenge = objA;
        else if (result <= 10)
            currentChallenge = objB;
        else
            currentChallenge = objC;
    }

    private int RandomChallenge(int numberStart, int numberEnd)
    {
        return Random.Range(numberStart, numberEnd);
    }
}
