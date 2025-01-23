using UnityEngine;

public class Tank_Turret : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;

    public float maxRotationSpeed = 100f; // Maximum rotation speed in degrees per second
    public float rotationAcceleration = 200f; // How quickly it accelerates
    public float rotationDeceleration = 100f; // How quickly it decelerates

    private float currentRotationSpeed = 0f; // Current rotational speed
    private float currentAngle = 0f; // Turret's current angle

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        // Get mouse position in world space
        mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCam.transform.position.z));

        // Calculate the direction to the mouse
        Vector2 direction = (mousePos - transform.position).normalized;

        // Calculate the desired angle
        float desiredAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Adjust for offset

        // Calculate angular difference
        float angleDifference = Mathf.DeltaAngle(currentAngle, desiredAngle);

        // Accelerate or decelerate based on angle difference
        if (Mathf.Abs(angleDifference) > 1f) // Prevent jitter
        {
            currentRotationSpeed += rotationAcceleration * Time.deltaTime;
        }
        else
        {
            currentRotationSpeed -= rotationDeceleration * Time.deltaTime;
        }

        // Clamp rotation speed
        currentRotationSpeed = Mathf.Clamp(currentRotationSpeed, 0f, maxRotationSpeed);

        // Apply rotation step
        float rotationStep = Mathf.Sign(angleDifference) * currentRotationSpeed * Time.deltaTime;
        rotationStep = Mathf.Clamp(rotationStep, -Mathf.Abs(angleDifference), Mathf.Abs(angleDifference)); // Prevent overshooting
        currentAngle += rotationStep;

        // Apply the new rotation in world space
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }
}
