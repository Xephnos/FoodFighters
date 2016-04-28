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

    void Update()
    {
        mouseX = Mathf.SmoothDamp(mouseX, Input.GetAxisRaw("Mouse X"), ref yRotVel, smoothRotation);

<<<<<<< HEAD
        horInput = Mathf.SmoothDamp(horInput, Input.GetAxisRaw("Horizontal"), ref xMoveVel, smoothMovement);
        vertInput = Mathf.SmoothDamp(vertInput, Input.GetAxisRaw("Vertical"), ref zMoveVel, smoothMovement);
=======
            float yVel = moveDir.y;
            float horInput = Input.GetAxisRaw("Horizontal");
            float vertInput = Input.GetAxisRaw("Vertical");
>>>>>>> origin/Developer

        moveDir = new Vector3(horInput, 0, vertInput);
        moveDir = transform.TransformDirection(moveDir);
        moveDir *= moveSpeed;
        moveDir = Vector3.ClampMagnitude(moveDir, moveSpeed);

<<<<<<< HEAD
        if (myMotor.IsGrounded())
        {
=======
            moveDir += (Vector3.up * yVel);

>>>>>>> origin/Developer
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myMotor.Jump(jumpForce);
            }
<<<<<<< HEAD
        }

        myMotor.Rotate(new Vector3(0, mouseX * rotateSpeed, 0));
        myMotor.Move(moveDir);
    }
}
=======

            moveDir.y += gravity * Time.deltaTime;

            moveDir = Vector3.ClampMagnitude(moveDir, moveSpeed);

            myMotor.Rotate(new Vector3(0, mouseX * rotateSpeed, 0));
            myMotor.Move(transform.rotation * moveDir);
    }
}
>>>>>>> origin/Developer
