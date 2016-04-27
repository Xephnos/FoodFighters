using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float jumpForce;
    public float gravity;

    private Vector3 moveDir;

    private PlayerMotor myMotor;

    void Awake()
    {
        myMotor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");

        if (myMotor.IsGrounded())
        {
            float horInput = Input.GetAxisRaw("Horizontal");
            float vertInput = Input.GetAxisRaw("Vertical");

            moveDir = new Vector3(horInput, 0, vertInput);
            moveDir *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDir.y = jumpForce;
            }
        }
        else
        {
            moveDir.y += gravity * Time.deltaTime;
        }
       
        moveDir = Vector3.ClampMagnitude(moveDir, moveSpeed);

        myMotor.Rotate(new Vector3(0, mouseX * rotateSpeed, 0));
        myMotor.Move(transform.rotation * moveDir);
    }  
}
