using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    private GameObject menus;
    private GameObject mainMenu;
    private GameObject gameMenu;
    private GameObject settingsMenu;
    private GameObject playerUI;
    private GameManager gMngr;

    void Awake()
    {
        gMngr = gameObject.transform.parent.GetComponent<GameManager>();
        menus = GameObject.FindGameObjectWithTag("Menus");
        mainMenu = menus.transform.FindChild("MainMenuUI").gameObject;
        gameMenu = menus.transform.FindChild("GameMenu").gameObject;
        settingsMenu = menus.transform.FindChild("SettingsMenu").gameObject;
        playerUI = menus.transform.FindChild("PlayerUI").gameObject;


    }

    void Start()
    {
        if (gMngr.gameState == GameState.Play)
        {
            mainMenu.SetActive(false);
            gameMenu.SetActive(false);
            settingsMenu.SetActive(false);
        }
        else if (gMngr.gameState == GameState.MainMenu)
        {
            gameMenu.SetActive(false);
            settingsMenu.SetActive(false);
            playerUI.SetActive(false);
        }
    }

    // Controls the state of the Game Menu.
    public void EnableDisableGameMenu()
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

    // Controls the state of the Settings Menu.
    public void EnableDisableSettingsMenu()
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

    //Checks the active state of the Settings Menu.
    public bool IsSettingsMenuActive()
    {
        if (settingsMenu.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }

    // Controls the state of the Player's UI.
    public void EnableDisablePlayerUI()
    {
        if (playerUI != null)
        {
            if (playerUI.activeInHierarchy)
            {
                playerUI.SetActive(false);
            }
            else
            {
                playerUI.SetActive(true);
            }
        }
    }
}
