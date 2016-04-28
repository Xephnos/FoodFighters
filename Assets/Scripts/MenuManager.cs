using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    private GameObject gameMenu;

    void Awake()
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
    }

    public void OpenCloseMenu()
    {
        print("World");
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
}
