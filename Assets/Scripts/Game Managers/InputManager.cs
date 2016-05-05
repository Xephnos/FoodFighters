using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    private GameManager gMngr;
    private PlayerController playerCont;
    private Dictionary<string, KeyCode> keys;

    private Vector3 movement = Vector3.zero;

    void Awake()
    {
        gMngr = gameObject.transform.parent.GetComponent<GameManager>();
    }

    void Start()
    {
        keys = gMngr.keybindingsManager.keybindings;
    }
	
	void Update ()
    {
        if (gMngr.gameState == GameState.Play || gMngr.gameState == GameState.GameMenu)
        {
            // Controls opening and closing the In-Game Menu.
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gMngr.uiManager.EnableDisableGameMenu();
                gMngr.uiManager.EnableDisablePlayerUI();

                if (gMngr.uiManager.IsSettingsMenuActive())
                {
                    gMngr.uiManager.EnableDisableSettingsMenu();
                }
            }
        }
    }

    // Player Input.
    void PlayerInput()
    {
        if ((Input.GetKey(keys["Forward"]) || Input.GetKey(keys["Left"]) || Input.GetKey(keys["Backward"]) || Input.GetKey(keys["Right"])))
        {
            if (Input.GetKey(keys["Forward"]))
            {
                movement.z = Vector3.forward.z;
            }
            else if (Input.GetKey(keys["Backward"]))
            {
                movement.z = -Vector3.forward.z;
            }
            else
            {
                movement.z = 0;
            }
            if (Input.GetKey(keys["Left"]))
            {
                movement.x = -Vector3.right.x;
            }
            else if (Input.GetKey(keys["Right"]))
            {
                movement.x = Vector3.right.x;
            }
            else
            {
                movement.x = 0;
            }

            gMngr.playerCont.Move(movement.normalized);
        }
        else
        {
            movement = Vector3.zero;
            gMngr.playerCont.Move(movement.normalized);
        }
        if (Input.GetKeyDown(keys["Jump"]))
        {
            gMngr.playerCont.Jump();
        }

        gMngr.playerCont.Rotate(Input.GetAxisRaw("Mouse X"));
    }

    // Camera Input.
    void CameraInput()
    {
        gMngr.camCont.LookUpAndDown(Input.GetAxisRaw("Mouse Y"));
    }

    // PUBLIC METHODS

    // Controls all input while the game is in Play State.
    // Uses the Update function.
    public void ControlPlayStateInput()
    {
        PlayerInput();
    }

    // Uses the LateUpdate function.
    public void ControlLatePlayStateInput()
    {
        CameraInput();
    }
}
