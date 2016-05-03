using UnityEngine;
using System.Collections;

public enum GameState
{
    MainMenu,
    GameMenu,
    Play
}

public class GameManager : MonoBehaviour
{
    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public MenuManager menuManager;
    [HideInInspector] public LevelManager levelManager;
    [HideInInspector] public KeybindingsManager keybindingsManager;

    public GameState gameState;

    void Awake()
    {
        inputManager = gameObject.transform.FindChild("InputManager").GetComponent<InputManager>();
        menuManager = gameObject.transform.FindChild("MenuManager").GetComponent<MenuManager>();
        levelManager = gameObject.transform.FindChild("LevelManager").GetComponent<LevelManager>();
        keybindingsManager = gameObject.transform.FindChild("KeybindingsManager").GetComponent<KeybindingsManager>();
    }
}
