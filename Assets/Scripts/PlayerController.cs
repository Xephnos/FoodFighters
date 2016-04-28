using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float smoothMovement;
    public float rotateSpeed;
    public float smoothRotation;
    public float jumpForce;
    
    private Vector3 moveDir;
    private float horInput, vertInput, mouseX;
    private float yRotVel, xMoveVel, zMoveVel; 

    private PlayerMotor myMotor;

    void Awake()
    {
        myMotor = GetComponent<PlayerMotor>();
    }

    void Start()
    {
        horInput = 0;
        vertInput = 0;
    }

    void Update()
    {
        mouseX = Mathf.SmoothDamp(mouseX, Input.GetAxisRaw("Mouse X"), ref yRotVel, smoothRotation);


        horInput = Mathf.SmoothDamp(horInput, Input.GetAxisRaw("Horizontal"), ref xMoveVel, smoothMovement);
        vertInput = Mathf.SmoothDamp(vertInput, Input.GetAxisRaw("Vertical"), ref zMoveVel, smoothMovement);

        moveDir = new Vector3(horInput, 0, vertInput);
        moveDir = transform.TransformDirection(moveDir);
        moveDir *= moveSpeed;
        moveDir = Vector3.ClampMagnitude(moveDir, moveSpeed);
        
        if (myMotor.IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myMotor.Jump(jumpForce);
            }
        }

        myMotor.Rotate(new Vector3(0, mouseX * rotateSpeed, 0));
        myMotor.Move(moveDir);
    }
}

          