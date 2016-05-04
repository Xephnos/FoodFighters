using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float smoothMoveX, smoothMoveZ;
    public float rotSensitivity;
    public float smoothRotation;
    public float jumpForce;
    
    private float distToGround;
    private float mouseX;

    private CharacterController myCharCont;
    private Collider myCollider;

    void Awake()
    {
        myCharCont = GetComponent<CharacterController>();
        myCollider = GetComponent<Collider>();
    }

    void Start()
    {
        distToGround = myCollider.bounds.extents.y;
    }

    private void MakeMeJump(float _jumpForce)
    {
        
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            MakeMeJump(jumpForce);
        }
    }

    public void Move(Vector3 _movement)
    {
        _movement = transform.TransformDirection(_movement);
        _movement *= moveSpeed;
        _movement = Vector3.ClampMagnitude(_movement, moveSpeed);

        myCharCont.Move(_movement * Time.deltaTime);
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

          