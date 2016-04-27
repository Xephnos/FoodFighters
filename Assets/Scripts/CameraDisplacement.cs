using UnityEngine;
using System.Collections;

public class CameraDisplacement : MonoBehaviour
{
    public Vector3 displacement;
    public float smoothMove;
    public float rayHitDisplacement;

    private Vector3 cameraDisplacement;
    private Vector3 targetCameraDisplacement;

    private Vector3 currentVelocity;

    private CameraFollow camFollow;
    private Transform cameraRaycastOrigin;

    void Awake()
    {
        camFollow = transform.parent.GetComponent<CameraFollow>();
    }

	void Start ()
    {
        cameraRaycastOrigin = GameObject.FindGameObjectWithTag("CameraRaycastOrigin").transform;
        UpdateCameraPosition(cameraDisplacement);
	}
	
	void LateUpdate ()
    {
        cameraDisplacement = displacement;

        Ray ray = new Ray(cameraRaycastOrigin.position, (transform.TransformPoint(cameraDisplacement) - cameraRaycastOrigin.position));
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, Vector3.Distance(transform.TransformPoint(cameraDisplacement), ray.origin)))
        {
            targetCameraDisplacement = Vector3.Lerp(transform.InverseTransformPoint(hit.point), cameraRaycastOrigin.localPosition, rayHitDisplacement);
        }
        else
        {
            targetCameraDisplacement = cameraDisplacement;
        }

        UpdateCameraPosition(targetCameraDisplacement);
	}

    void UpdateCameraPosition(Vector3 _position)
    {
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, _position, ref currentVelocity, smoothMove * Time.deltaTime);
    }
}
