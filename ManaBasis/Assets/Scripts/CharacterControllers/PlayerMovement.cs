using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public KeyCode jump = KeyCode.Space;

    public float forwardSpeed, strafeSpeed, backSpeed;
    public float jumpForce;
    public bool grounded;

    Rigidbody rb;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if(Input.GetKey(forward))
        {
            rb.MovePosition(transform.position + transform.forward * forwardSpeed * Time.deltaTime);
        }
        if (Input.GetKey(left))
        {
            rb.MovePosition(transform.position - transform.right * forwardSpeed * Time.deltaTime);
        }
        if (Input.GetKey(right))
        {
            rb.MovePosition(transform.position + transform.right * forwardSpeed * Time.deltaTime);
        }
        if (Input.GetKey(back))
        {
            rb.MovePosition(transform.position - transform.forward * forwardSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(jump) && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) { grounded = true; }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) { grounded = false; }
    }
}
