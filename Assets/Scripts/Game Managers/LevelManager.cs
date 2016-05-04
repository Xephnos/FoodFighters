using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string _levelName)
    {
        SceneManager.LoadScene(_levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
