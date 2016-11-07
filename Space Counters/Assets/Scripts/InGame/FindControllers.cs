using UnityEngine;
using System.Collections;

public class FindControllers : MonoBehaviour {

    private GameController gameController;
    private PlayerController playerController;

    public GameController FindGameController()
    {
        string tag = TagConstantStrings.GAMECONTROLLER;

        if (VerifyIfControllerExists(tag))
        {
            GameObject controller = GameObject.FindWithTag(tag);
            gameController = controller.GetComponent<GameController>();
        }

        return gameController;
    }

    public PlayerController FindPlayerController()
    {
        string tag = TagConstantStrings.PLAYER;

        if (VerifyIfControllerExists(tag))
        {
            GameObject controller = GameObject.FindWithTag(tag);
            playerController = controller.GetComponent<PlayerController>();
        }

        return playerController;
    }

    public bool VerifyIfControllerExists(string tag)
    {
        GameObject controller = GameObject.FindWithTag(tag);

        if (controller != null)
        {
            return true;
        }

        if (controller == null)
        {
            Debug.Log("Cannot find 'Controller' script");
            return false;
        }

        return false;
    }

}
