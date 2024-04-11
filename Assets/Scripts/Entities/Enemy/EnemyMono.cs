using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMono : MonoBehaviour
{
    private Collider2D currentTarget;
    private Collision2D currentDamage;
    public event Action<float> GetDamage;
    public float Damage;

    public Collider2D CurrentTarget { get { return currentTarget; } }
    public Collision2D CurrentDamage { get { return currentDamage; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentTarget = collision;
            Debug.Log("Enemy can approuch");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentTarget = null;
            Debug.Log("Enemy can't approuch");
        }
    }

    public void GotDamage(float damage)
    {
        GetDamage?.Invoke(damage);
    }
}
