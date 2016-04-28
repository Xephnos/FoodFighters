using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string _levelName)
    {
        Application.LoadLevel(_levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
