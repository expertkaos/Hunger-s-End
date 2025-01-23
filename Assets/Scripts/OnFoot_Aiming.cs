using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;

    public float rotationSmoothness = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get mouse position in world space
        mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCam.transform.position.z));

        // Calculate the direction to the mouse
        Vector2 direction = (mousePos - transform.position).normalized;

        // Calculate the desired angle
        //IDFK just some angle bullshit don't ask me how it works
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Target rotation as a quaternion
        Quaternion targetRotation = Quaternion.Euler(0, 0, rotZ);

        // Smoothly interpolate rotation towards the target
        rb.rotation = Mathf.LerpAngle(rb.rotation, rotZ, rotationSmoothness * Time.fixedDeltaTime);
    }
}
