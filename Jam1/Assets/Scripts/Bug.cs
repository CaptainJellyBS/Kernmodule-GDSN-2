using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public float moveSpeed, damageValue;
    private void Start()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 4.82f) - transform.position, Vector3.up);
    }

    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Programmer"))
        {
            GameManager.Instance.TakeDamage(damageValue);
            Destroy(gameObject);
        }

        if(other.CompareTag("Bubble"))
        {
            Destroy(gameObject);
        }
    }
}
