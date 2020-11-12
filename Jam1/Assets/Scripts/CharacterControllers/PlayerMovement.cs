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
    public KeyCode up = KeyCode.Space;
    public KeyCode down = KeyCode.LeftShift;

    public GameObject bubble, bugSpray;

    public float fireRate;
    public float moveSpeed;
    public float jumpForce;
    public bool grounded;

    public int ammo = 50;
    public ScoreUI ammoUI;

    public Transform duckPos;

    bool canFireBubble;
    public bool isInDuck;

    Rigidbody rb;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        canFireBubble = true;
        isInDuck = false;
        ammoUI.ScoreValue = ammo;
    }

    private void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKey(forward))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(left))
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(right))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(back))
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(up))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(down))
        {
            transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
        }

        if (Input.GetMouseButton(0) && canFireBubble)
        {
            Shoot();
        }    
    }

    void Shoot()
    {
        if (isInDuck) { return; }
        if(ammo<1) { return; }
        canFireBubble = false;
        ammo--;
        ammoUI.ScoreValue = ammo;

        StartCoroutine(ReloadBubble());
        Instantiate(bubble, transform.position + transform.forward + transform.up * 0.5f, Camera.main.transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) { grounded = true; }
        if(collision.collider.CompareTag("Enemy")) { TeleportToDuck(); }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) { grounded = false; }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GREEJKSLj");

        ammo = 50;
        ammoUI.ScoreValue = ammo;

        if (other.gameObject.CompareTag("Duck"))
        {
            isInDuck = true;
            StartCoroutine(FixCode());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Duck"))
        {
            isInDuck = false;
        }
    }

    IEnumerator ReloadBubble()
    {
        yield return new WaitForSeconds(1 / fireRate);
        canFireBubble = true;
    }

    public void TeleportToDuck()
    {
        transform.position = duckPos.position;
    }

    IEnumerator FixCode()
    {
        while(isInDuck)
        {
            yield return new WaitForSeconds(GameManager.Instance.timeBetweenSteps*2);
            GameManager.Instance.TakeDamage(-0.01f);
        }
    }
}
