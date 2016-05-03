using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    private GameManager gMngr;

    void Awake()
    {
        gMngr = gameObject.transform.parent.GetComponent<GameManager>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gMngr.menuManager.OpenCloseGameMenu();
        }
	}
}
