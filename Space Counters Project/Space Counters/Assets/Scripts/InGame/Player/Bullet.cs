using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private FindControllers findGameController;
    private GameController gameController;

    void Start()
    {
        findGameController = GetComponent<FindControllers>();
        gameController = findGameController.FindGameController();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagConstantStrings.ENEMY)
        {
            var enemy = other.GetComponent<EnemyController>();

            int enemyValue = enemy.GetEnemyValue();

            if(enemy.CheckIfEnemyDie())
            {
                gameController.AddValue(enemyValue);
            }
            
            DestroyBullet();

        }                
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
