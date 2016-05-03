using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private GameManager gMngr;

    void Awake()
    {
        gMngr = gameObject.transform.parent.GetComponent<GameManager>();
    }

    public void LoadLevel(string _levelName)
    {
        Application.LoadLevel(_levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
