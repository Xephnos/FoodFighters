﻿using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    private GameObject gameMenu;
    private GameObject settingsMenu;

    void Awake()
    {
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
            }
            else
            {
                gameMenu.SetActive(true);
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
