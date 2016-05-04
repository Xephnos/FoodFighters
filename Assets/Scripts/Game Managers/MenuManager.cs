using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    private GameObject gameMenu;
    private GameObject settingsMenu;
    private GameManager gMngr;

    void Awake()
    {
        gMngr = gameObject.transform.parent.GetComponent<GameManager>();
        DeclareMenus();
    }

    private void DeclareMenus()
    {
        if (gameMenu == null)
        {
            gameMenu = GameObject.FindGameObjectWithTag("GameMenu");

            if (gameMenu == null)
            {
                gameMenu = null;
            }
            else
            {
                gameMenu.SetActive(false);
            }
        }

        if (settingsMenu == null)
        {
            settingsMenu = GameObject.FindGameObjectWithTag("SettingsMenu");

            if (settingsMenu == null)
            {
                settingsMenu = null;
            }
            else
            {
                settingsMenu.SetActive(false);
            }
        }
    }

    public void OpenCloseGameMenu()
    {
        if (gameMenu != null)
        {
            if (gameMenu.activeInHierarchy)
            {
                gameMenu.SetActive(false);
                gMngr.gameState = GameState.Play;
            }
            else
            {
                gameMenu.SetActive(true);
                gMngr.gameState = GameState.GameMenu;
            }
        }
    }

    public void OpenCloseSettingsMenu()
    {
        if (settingsMenu != null)
        {
            if (settingsMenu.activeInHierarchy)
            {
                settingsMenu.SetActive(false);
            }
            else
            {
                settingsMenu.SetActive(true);
            }
        }
    }
}
