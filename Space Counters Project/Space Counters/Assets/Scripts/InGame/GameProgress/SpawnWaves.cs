using UnityEngine;
using System.Collections;

public class SpawnWaves : Component {
    private GameController gameController;

    public void GetGameControllerReference(GameController gameController)
    {
        this.gameController = gameController;
    }

    // spawning waves
    public IEnumerator SpawningWaves()
    {
        yield return new WaitForSeconds(gameController.startWait);

        while (gameController.ContinueSpawnWaves)
        {

            for (int i = 0; i < gameController.enemyNumberPerWave; i++)
            {
                GameObject enemyNumber = gameController.enemyNumbers[Random.Range(0, gameController.enemyNumbers.Length)];

                Vector3 spawnPosition = new Vector3(
                    Random.Range(-gameController.spawnValues.x, gameController.spawnValues.x),
                    gameController.spawnValues.y,
                    gameController.spawnValues.z
                );
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(enemyNumber, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(gameController.startWait);
            }

            yield return new WaitForSeconds(gameController.waveWait);

            if (gameController.GameOverFlag)
            {
                new GameOver(gameController.DisplayText, gameController);
                break;
            }
        }
    }
}
