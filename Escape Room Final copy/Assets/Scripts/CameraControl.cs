using UnityEngine;

[ExecuteInEditMode]
public class CameraControl : MonoBehaviour
{
    [System.Serializable]
    public class CameraSettings
    {
        [Header("Camera Move Settings")]
        public float zoomSpeed = 5;
        public float moveSpeed = 5;
        public float rotationSpeed = 5;
        public float originalFieldOfView = 70;
        public float zoomFieldOfView = 20;
        public float MouseX_Sensitivity = 5;
        public float MouseY_Sensitivity = 5;
        public float MaxClampAngle = 90;
        public float MinClampAngle = 30;
    }

    [SerializeField]
    public CameraSettings cameraSettings;

    [System.Serializable]
    public class CameraInputSettings
    {
        public string MouseXAxis = "Mouse X";
        public string MouseYAxis = "Mouse Y";
        public string AimingInput = "Fire2";
    }

    [SerializeField]
    public CameraInputSettings inputSettings;

    Transform center;
    Transform target;

    Camera mainCam;

    float cameraXRotation = 0;
    float cameraYRotation = 0;

    [Header("Camera Follow Settings")]
    public Transform followTarget; // Assign the target (e.g., the player) in the Inspector
    public float followSpeed = 5.0f;

    private void Start()
    {
        mainCam = Camera.main;
        center = transform.GetChild(0);
        FindPlayer();
    }

    private void Update()
    {
        if (!target)
            return;

        if (!Application.isPlaying)
            return;

        RotateCamera();
        ZoomCamera();

        FollowTarget();
    }

    private void FindPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FollowTarget()
    {
        if (followTarget)
        {
            Vector3 targetPosition = followTarget.position;
            targetPosition.y = transform.position.y; // Maintain the camera's Y position
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    private void RotateCamera()
    {
        cameraXRotation += Input.GetAxis(inputSettings.MouseYAxis) * cameraSettings.MouseY_Sensitivity;
        cameraYRotation += Input.GetAxis(inputSettings.MouseXAxis) * cameraSettings.MouseX_Sensitivity;

        cameraXRotation = Mathf.Clamp(cameraXRotation, cameraSettings.MinClampAngle, cameraSettings.MaxClampAngle);
        cameraYRotation = Mathf.Repeat(cameraYRotation, 360);

        Vector3 rotatingAngle = new Vector3(cameraXRotation, cameraYRotation, 0);
        Quaternion rotation = Quaternion.Slerp(center.transform.localRotation, Quaternion.Euler(rotatingAngle), cameraSettings.rotationSpeed * Time.deltaTime);
        center.transform.localRotation = rotation;
    }

    private void ZoomCamera()
    {
        if (Input.GetButton(inputSettings.AimingInput))
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, cameraSettings.zoomFieldOfView, cameraSettings.zoomSpeed * Time.deltaTime);
        }
        else
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, cameraSettings.originalFieldOfView, cameraSettings.zoomSpeed * Time.deltaTime);
        }
    }
}
