using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public float hp;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0) { Destroy(gameObject); }
        Debug.Log("Took " + damage + " damage");
        GetComponent<Player>()?.TakeDamage(damage);
    }
}
