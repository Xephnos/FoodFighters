using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    private MenuManager menuMngr;

    void Awake()
    {
        menuMngr = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Hello");
            menuMngr.OpenCloseMenu();
        }
	}
}
