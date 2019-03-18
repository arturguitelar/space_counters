using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public int enemyValue;
    public int lives;
    public float speed;

    public Material[] materials;

    public GameObject explosion;

    private FindControllers findGameController;
    private GameController gameController;

    private bool isTriggered = false;

    void Start()
    {
        ChangeEnemySpeed();

        findGameController = GetComponent<FindControllers>();
        gameController = findGameController.FindGameController();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagConstantStrings.BOUNDARY)
        {
            return;
        }

        if (other.tag == TagConstantStrings.PLAYER)
        {
            if (isTriggered == false)
            {
                isTriggered = true;

                Dead();

                gameController.HitPlayer();
            }
                        
        }

    }

    public int GetEnemyValue()
    {
        return enemyValue;
    }

    private void DecreaseEnemyLive()
    {
        lives--;
    }

    public bool CheckIfEnemyDie()
    {
        if (lives == 3)
        {
            PaintEnemy(1);
            NoDead();

            return false;
        }

        if (lives == 2)
        {
            PaintEnemy(0);
            NoDead();

            return false;
        }

        if (lives == 1)
        {
            Dead();

            return true;
        }

        return false;
    }

    private void NoDead()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        DecreaseEnemyLive();
    }

    private void Dead()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }

    private void ChangeEnemySpeed()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        DifficultEnemies difficult = new DifficultEnemies();

        speed = difficult.GenerateDifficultSpeed(speed);
        rigidbody.velocity = transform.forward * speed;
    }

    private void PaintEnemy(int material)
    {
        var enemyChildren = gameObject.GetComponentsInChildren<MeshRenderer>();

        for (var i = 0; i < enemyChildren.Length; i++)
        {
            enemyChildren[i].GetComponent<MeshRenderer>().sharedMaterial = materials[material];
        }
    }
}
