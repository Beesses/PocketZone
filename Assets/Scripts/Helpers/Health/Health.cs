using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public event Action<float> Changed;
    public event Action Died;

    private float health;

    public Health(float value)
    {
        health = value;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        Changed?.Invoke(health);

        if(health <= 0)
        {
            Died?.Invoke();
        }

        //Debug.Log(health);
    }
}
