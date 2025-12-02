using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.8f;

    CharacterController controller;
    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Apply gravity
        if (controller.isGrounded)
        {
            velocity.y = -2f; // Keep grounded with slight downward velocity
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = jumpForce;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
