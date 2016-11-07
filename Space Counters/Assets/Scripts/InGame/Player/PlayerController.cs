using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed, tilt, fireRate;
    public int lives;

    public Boundary boundary;
    public GameObject shot, playerExplosion;
    public Transform shotSpawn;

    private Rigidbody rb;
    private bool canSHoot;
    private PlayerMovement movement;
    private Shoot shoot;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        movement = new PlayerMovement();

        shoot = new Shoot();
        canSHoot = true;
    }

    void Update()
    {
        shoot.Fire(this);
    }

    void FixedUpdate()
    {
        movement.Movement(rb, this);
    }

    public bool GetCanShoot()
    {
        return canSHoot;
    }


    public int GetLives()
    {
        return lives;
    }

    public void DecreaseLives()
    {
        lives--;
    }

    public bool CheckIfPlayerDie()
    {
        if(lives <= 0)
        {
            return true;
        }

        return false;
    }

    public void Die()
    {
        InstantiatePlayerExplosion();
        Destroy(gameObject);
    }

    public void InstantiatePlayerExplosion()
    {
        Instantiate(playerExplosion, transform.position, transform.rotation);
    }

    public void PlayerWait()
    {
        canSHoot = false;

        foreach (Collider colli in rb.GetComponents<Collider>())
        {
            colli.enabled = false;
        }
    }

    public void PlayerAwake() {
        canSHoot = true;

        if (rb != null)
        {
            foreach (Collider colli in rb.GetComponents<Collider>())
            {
                colli.enabled = true;
            }
        }            
    }
}
