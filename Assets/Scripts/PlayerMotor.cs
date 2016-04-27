using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    public float smoothMovement;

    private float distToGround;

    private CharacterController charController;
    private Collider myCollider;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
        myCollider = GetComponent<Collider>();
    }

    void Start()
    {
        distToGround = myCollider.bounds.extents.y;
    }

    public void Move(Vector3 movement)
    {
        charController.Move(movement * Time.deltaTime);
    }

    public void Rotate(Vector3 rotation)
    {
        transform.rotation *= Quaternion.EulerAngles(rotation * Time.deltaTime);
    }

    public void Jump()
    {

    }

    public bool IsGrounded()
    {
        //return charController.isGrounded;
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
