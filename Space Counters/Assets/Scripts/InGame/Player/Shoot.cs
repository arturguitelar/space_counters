using UnityEngine;
using System.Collections;
using System;

public class Shoot : Component {

    private float nextFire = 0.2f;

    public void Fire(PlayerController player)
    {
        if (player.GetCanShoot())
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + player.fireRate;
                Instantiate(player.shot, player.shotSpawn.position, player.shotSpawn.rotation);
            }
        }
    }
}
