using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private float distToGround;

    private Vector3 currentVelocity;

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

    public void Move(Vector3 movement)
    {
        transform.position += movement * Time.deltaTime;
    }

    public void Rotate(Vector3 rotation)
    {
        transform.rotation *= Quaternion.EulerAngles(rotation * Time.deltaTime);
    }

    public void Jump(float _jumpForce)
    {
        myRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
