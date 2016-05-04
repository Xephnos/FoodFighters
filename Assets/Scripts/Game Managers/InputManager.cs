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
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gMngr.menuManager.OpenCloseGameMenu();
            }
        }
    }

    // Player Movement Input
    void PlayerMovement()
    {
        if ((Input.GetKey(keys["Forward"]) || Input.GetKey(keys["Left"]) || Input.GetKey(keys["Backward"]) || Input.GetKey(keys["Right"])))
        {
            if (Input.GetKey(keys["Forward"]))
            {
                movement.z = Mathf.Lerp(movement.z, Vector3.forward.z, gMngr.playerCont.smoothMoveZ * Time.deltaTime);
            }
            else if (Input.GetKey(keys["Backward"]))
            {
                movement.z = Mathf.Lerp(movement.z, -Vector3.forward.z, gMngr.playerCont.smoothMoveZ * Time.deltaTime);
            }
            else
            {
                movement.z = Mathf.Lerp(movement.z, 0, gMngr.playerCont.smoothMoveZ * Time.deltaTime);
            }
            if (Input.GetKey(keys["Left"]))
            {
                movement.x = Mathf.Lerp(movement.x, -Vector3.right.x, gMngr.playerCont. smoothMoveX * Time.deltaTime);
            }
            else if (Input.GetKey(keys["Right"]))
            {
                movement.x = Mathf.Lerp(movement.x, Vector3.right.x, gMngr.playerCont.smoothMoveX * Time.deltaTime);
            }
            else
            {
                movement.x = Mathf.Lerp(movement.x, 0, gMngr.playerCont.smoothMoveX * Time.deltaTime);
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

    void CameraMovement()
    {
        gMngr.camCont.LookUpAndDown(Input.GetAxisRaw("Mouse Y"));
    }

    // PUBLIC METHODS

    // Controls all input while the game is in Play State.
    public void ControlPlayStateInput()
    {
        PlayerMovement();
    }

    public void ControlLatePlayStateInput()
    {
        CameraMovement();
    }
}
