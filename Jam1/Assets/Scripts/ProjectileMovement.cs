using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float moveSpeed;

    public void Init(float speed)
    {
        moveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        if (transform.position.y > 12.0f || transform.position.y < -12.0f || transform.position.x > 16.0f || transform.position.x < -16.0f || transform.position.z > 16.0f || transform.position.z < -16.0f)
        {
            Destroy(gameObject);
        }
    }
}
