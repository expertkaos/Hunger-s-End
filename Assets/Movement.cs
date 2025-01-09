using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Lumin;

public class Movement : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame - used for inputs and timers
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize(); // makes the diagonal movement move the same as other movements
                           //Without normalize - diagonal movement would be faster
    }

    
    //Called once per physics frame - used for physics 
    private void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }

}
    