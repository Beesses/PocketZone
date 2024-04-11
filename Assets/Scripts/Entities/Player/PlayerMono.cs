using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerMono : MonoBehaviour
{
    private Collider2D currentTarget;
    public event Action<float> Damage;
    public event Action<EnemyMono> Attack;
    public event Action<Sprite> Item;
    private List<EnemyMono> enemyMonos = new List<EnemyMono>();

    public Collider2D CurrentTarget { get { return currentTarget; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyMono enemy))
        {
            enemyMonos.Add(enemy);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyMono enemy))
        {
            closestEnemy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyMono enemy))
        {
            Damage?.Invoke(enemy.Damage);
        }
        else if (collision.gameObject.TryGetComponent(out ItemMono item))
        {
            Item?.Invoke(item.ItemSprite);
            Destroy(item.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyMono enemy))
        {
            enemyMonos.Remove(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            currentTarget = null;
            Debug.Log("Can't attack");
        }
    }

    private void closestEnemy()
    {
        EnemyMono closestObject = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (var objectInTrigger in enemyMonos)
        {
            if(objectInTrigger != null)
            {
                float sqrDistanceToObject = (objectInTrigger.transform.position - currentPosition).sqrMagnitude;
                if (sqrDistanceToObject < closestDistanceSqr)
                {
                    closestDistanceSqr = sqrDistanceToObject;
                    closestObject = objectInTrigger;
                }
            }
        }
        Attack?.Invoke(closestObject);
    }
}
