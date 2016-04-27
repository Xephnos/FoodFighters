using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public float moveSpeed;

    private Transform cameraTarget;
    private Transform newCameraTarget;
    private bool autoTarget;

    void Awake()
    {
        newCameraTarget = GameObject.FindGameObjectWithTag("CameraTarget").transform;
    }
	
	void Start ()
    {
        autoTarget = true;

        if (autoTarget)
        {
            FindTarget();
        }
	}

	void LateUpdate ()
    {
        if (autoTarget && (cameraTarget == null || !cameraTarget.gameObject.activeSelf))
        {
            FindTarget();
        }
        if (cameraTarget != null)
        {
            Follow(cameraTarget);
        }
	}

    void FindTarget()
    {
        if (cameraTarget == null)
        {
            SetCameraTarget(newCameraTarget);
        }
    }

    void Follow(Transform _target)
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position, moveSpeed * Time.deltaTime);
        transform.rotation = _target.rotation;
    }

    // PUBLIC METHODS
    public void SetCameraTarget(Transform _target)
    {
        cameraTarget = _target;
    }

    public void SwitchTarget(Transform _target)
    {
        newCameraTarget = _target;
        SetCameraTarget(newCameraTarget);
    }
}
