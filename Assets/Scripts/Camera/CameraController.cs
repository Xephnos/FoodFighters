using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float rotSensitivity;
    public float smoothRotation;
    public float minRot, maxRot;

    private float mouseY;

    public void LookUpAndDown(float _mouseY)
    {
        mouseY -= _mouseY * rotSensitivity;
        mouseY = Mathf.Clamp(mouseY, minRot, maxRot);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(mouseY, transform.localEulerAngles.y, 0)), smoothRotation * Time.deltaTime);
    }
}
