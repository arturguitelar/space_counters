using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject tutorialSubmenu;
    public GameObject creditSubmenu;
    public GameObject difficultMenu;

    public void ActiveDifficultMenu()
    {
        Instantiate(difficultMenu);
    }

    public void ActiveSubmenu(int submenuNumber)
    {
        switch(submenuNumber)
        {
            case 1:
                Instantiate(tutorialSubmenu);
                break;

            case 2:
                Instantiate(creditSubmenu);
                break;

            default:
                Debug.Log("Something is wrong");
                break;
        }        
    }

    public void ExitGame()
    {
        new ExitGame();
    }
}
