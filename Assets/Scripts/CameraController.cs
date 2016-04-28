using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float rotSensitivity;
    public float minRot, maxRot;

    private float mouseY;

	void Start ()
    {
	
	}


    void LateUpdate()
    {
        mouseY -= Input.GetAxisRaw("Mouse Y") * rotSensitivity;
        mouseY = Mathf.Clamp(mouseY, minRot, maxRot);

        transform.localEulerAngles = new Vector3(mouseY, transform.localEulerAngles.y, 0);
    }
}
