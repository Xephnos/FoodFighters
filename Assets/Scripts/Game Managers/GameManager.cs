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

    public GameObject player;
    public PlayerController playerCont;
    public GameObject mainCam;
    public CameraController camCont;

    void Awake()
    {
        inputManager = gameObject.transform.FindChild("InputManager").GetComponent<InputManager>();
        menuManager = gameObject.transform.FindChild("MenuManager").GetComponent<MenuManager>();
        levelManager = gameObject.transform.FindChild("LevelManager").GetComponent<LevelManager>();
        keybindingsManager = gameObject.transform.FindChild("KeybindingsManager").GetComponent<KeybindingsManager>();

        if (gameState == GameState.Play)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerCont = player.GetComponent<PlayerController>();
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").transform.parent.gameObject;
            camCont = mainCam.GetComponent<CameraController>();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (gameState == GameState.Play)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            inputManager.ControlPlayStateInput();
        }
        else if (gameState == GameState.GameMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (gameState == GameState.MainMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void UpdateCursorState()
    {
        
    }

    void LateUpdate()
    {
        if (gameState == GameState.Play)
        {
            inputManager.ControlLatePlayStateInput();
        }
    }
}
