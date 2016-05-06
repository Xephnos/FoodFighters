using UnityEngine;
using System.Collections;

public enum GameState
{
    SplashScreen,
    MainMenu,
    GameMenu,
    Play
}

public enum GameMode
{
    None,
    CaptureTheTest,
    FoodWars
}

public class GameManager : MonoBehaviour
{
    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public UIManager uiManager;
    [HideInInspector] public LevelManager levelManager;
    [HideInInspector] public KeybindingsManager keybindingsManager;
    [HideInInspector] public TimeManager timeManager;

    [HideInInspector] public GameObject player;
    [HideInInspector] public PlayerController playerCont;
    [HideInInspector] public GameObject mainCam;
    [HideInInspector] public CameraController camCont;

    public GameState gameState;
    public GameMode gameMode;

    void Awake()
    {
        inputManager = gameObject.transform.FindChild("InputManager").GetComponent<InputManager>();
        uiManager = gameObject.transform.FindChild("UIManager").GetComponent<UIManager>();
        levelManager = gameObject.transform.FindChild("LevelManager").GetComponent<LevelManager>();
        keybindingsManager = gameObject.transform.FindChild("KeybindingsManager").GetComponent<KeybindingsManager>();
        timeManager = gameObject.transform.FindChild("TimeManager").GetComponent<TimeManager>();

        if (gameState == GameState.Play)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerCont = player.GetComponent<PlayerController>();
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").transform.parent.gameObject;
            camCont = mainCam.GetComponent<CameraController>();
        }
    }

    void Update()
    {
        if (gameState == GameState.Play)
        {
            LockCursor();
            inputManager.ControlPlayStateInput();
        }
        else if (gameState == GameState.GameMenu)
        {
            UnlockCursor();
        }
        else if (gameState == GameState.MainMenu)
        {
            UnlockCursor();
        }
    }

    void LateUpdate()
    {
        if (gameState == GameState.Play)
        {
            inputManager.ControlLatePlayStateInput();
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
