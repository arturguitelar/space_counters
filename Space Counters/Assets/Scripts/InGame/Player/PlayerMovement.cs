using UnityEngine;
using System.Collections;

public class PlayerMovement {

    private Vector3 movement;
    private float moveHorizontal, moveVertical;

    public void Movement(Rigidbody player, PlayerController playerController)
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        player.velocity = movement * playerController.speed;

        player.position = new Vector3
        (
            Mathf.Clamp(player.position.x, playerController.boundary.xMin, playerController.boundary.xMax),
            0.0f,
            Mathf.Clamp(player.position.z, playerController.boundary.zMin, playerController.boundary.zMax)
        );

        if (player.rotation.x != 0.0f || player.rotation.y != 0.0f)
        {
            Quaternion.Euler(0.0f, 0.0f, player.velocity.x * -playerController.tilt);
        }

        player.rotation = Quaternion.Euler(0.0f, 0.0f, player.velocity.x * -playerController.tilt);

    }
}
