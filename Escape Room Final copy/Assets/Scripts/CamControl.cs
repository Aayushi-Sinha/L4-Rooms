using UnityEngine;

public class CamControl : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this to control camera movement speed
    public float rotationSpeed = 2.0f; // Adjust this to control camera rotation speed

    private Transform player; // Reference to the player's transform

    private void Start()
    {
        // Find and store a reference to the player's transform (assuming the player has a "Player" tag)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Check for camera movement input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate camera movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        // Apply camera movement relative to camera rotation
        Vector3 cameraForward = transform.forward;
        cameraForward.y = 0.0f; // Keep the camera horizontal
        cameraForward.Normalize();
        Vector3 cameraRight = transform.right;
        cameraRight.y = 0.0f; // Keep the camera horizontal
        cameraRight.Normalize();

        Vector3 newPosition = transform.position +
            (cameraForward * moveDirection.z + cameraRight * moveDirection.x) * moveSpeed * Time.deltaTime;

        // Move the camera
        transform.position = newPosition;

        // Check for camera rotation input
        float rotationInput = Input.GetAxis("Rotation");

        // Rotate the camera
        transform.RotateAround(player.position, Vector3.up, rotationInput * rotationSpeed);
    }
}
