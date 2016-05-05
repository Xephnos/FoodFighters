using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float moveSpeedDelay;
    public float moveDelay;
    public float rotSensitivity;
    public float smoothRotation;
    public float jumpForce;
    
    private float distToGround;
    private float mouseX;
    private float moveSpeedLimit;
    private Vector3 movement;
    private Vector3 moveVelocity;

    private Rigidbody myRigidbody;
    private Collider myCollider;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
    }

    void Start()
    {
        distToGround = myCollider.bounds.extents.y;
    }

    private void MakeMeJump(float _jumpForce)
    {
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpForce, myRigidbody.velocity.z);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            MakeMeJump(jumpForce);
        }
    }

    public void Move(Vector3 _targetMovement)
    {
        if (!IsGrounded())
        {
            moveSpeedLimit = Mathf.Lerp(moveSpeedLimit, (moveSpeed / 2f), moveSpeedDelay * Time.deltaTime);
        }
        else
        {
            moveSpeedLimit = moveSpeed;
        }

        _targetMovement *= moveSpeedLimit;
        _targetMovement = Vector3.ClampMagnitude(_targetMovement, moveSpeedLimit);

        movement = Vector3.SmoothDamp(movement, _targetMovement, ref moveVelocity, moveDelay);

        transform.Translate(movement * Time.deltaTime);
    }

    public void Rotate(float _mouseX)
    {
        mouseX += _mouseX * rotSensitivity;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, mouseX, 0)), smoothRotation * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}

          