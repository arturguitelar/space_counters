using UnityEngine;
using System.Collections;

public class PhaseCheater {

    private SceneController scene;

    public void ChangeThePhase()
    {
        scene = new SceneController();

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {           
            scene.SetCurrentScene(0);
            scene.GoToNextPhase();
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            scene.SetCurrentScene(1);
            scene.GoToNextPhase();
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            scene.SetCurrentScene(2);
            scene.GoToNextPhase();
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            scene.SetCurrentScene(3);
            scene.GoToNextPhase();
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            scene.SetCurrentScene(4);
            scene.GoToNextPhase();
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            scene.SetCurrentScene(5);
            scene.GoToNextPhase();
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            scene.SetCurrentScene(6);
            scene.GoToNextPhase();
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            scene.SetCurrentScene(7);
            scene.GoToNextPhase();
        }
    }
}
