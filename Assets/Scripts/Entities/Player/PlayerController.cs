using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public sealed class PlayerController
{
    private PlayerModel model; 
    private Vector2 move;
    private float timer = 0;

    public PlayerController(InventoryController inventory)
    {
        model = new PlayerModel((PlayerData)AssetDatabase.LoadAssetAtPath("Assets/Data/Player.asset", typeof(PlayerData)));
        model.MyHealth.Died += Died;
        model.Mono.Damage += model.MyHealth.TakeDamage;
        model.Mono.Attack += Attack;
        model.Mono.Item += inventory.setItem;
    }

    public Transform Target()
    {
        return model.Prefab.transform;
    }

    public void Updating()
    {
        move = model.Joystick.action.ReadValue<Vector2>();
        timer += Time.deltaTime;
    }

    private void Attack(EnemyMono enemy)
    {
        if(model.Attack.action.ReadValue<float>() == 1)
        {
            if(model.currentBullets > 0)
            {
                if (timer > 1)
                {
                    model.currentBullets--;
                    Debug.Log(model.currentBullets);
                    enemy.GotDamage(model.Damage);
                    timer = 0;
                }
            }
            else
            {
                Reload();
            }
        }
    }

    private void Reload()
    {
        timer = 0;
        model.currentBullets = model.BulletCapacity;
    }

    public void FixedUpdating()
    {
        if(model.Prefab != null)
        {
            model.RB.AddRelativeForce(move);
        }
    }

    private void Died()
    {
        model.MyHealth.Died -= Died;
        model.Mono.Damage -= model.MyHealth.TakeDamage;
        model.Mono.Attack -= Attack;
        GameObject.Destroy(model.Prefab);
    }
}
