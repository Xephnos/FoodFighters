using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float jumpForce;

    private Vector3 moveDir;

    private PlayerMotor myMotor;

    void Awake()
    {
        myMotor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float horInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical");

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
