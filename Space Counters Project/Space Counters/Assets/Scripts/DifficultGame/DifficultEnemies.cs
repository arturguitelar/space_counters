using UnityEngine;
using System.Collections;

public class DifficultEnemies : DifficultGenerator {
    public float GenerateDifficultSpeed(float enemySpeed)
    {
        int difficult = GetDifficultLevel();

        switch (difficult)
        {
            case 1:
                enemySpeed *= 1;
                break;

            case 2:
                enemySpeed *= 2;
                break;

            case 3:
                enemySpeed *= 3;
                break;
        }

        return enemySpeed;
    }
}
