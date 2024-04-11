using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class EnemyModel
{
    private GameObject prefab;
    private float speed;
    private float damage;
    private Rigidbody2D rb;
    private EnemyMono mono;
    private Health health;
    public Transform target;
    public event Action<EnemyModel> RemoveModel;

    public GameObject Prefab { get { return prefab; } }
    public Health MyHealth { get { return health; } }
    public float Speed { get { return speed; } }
    public float Damage { get { return damage; } }
    public Rigidbody2D RB { get { return rb; } }
    public EnemyMono Mono { get { return mono; } }

    public EnemyModel(EnemyData data, Vector2 pos)
    {
        speed = data.speed;
        damage = data.damage;
        prefab = GameObject.Instantiate(data.prefab);
        GameObject healthCanvas = GameObject.Instantiate(data.HelathCanvas);
        healthCanvas.transform.SetParent(prefab.transform);
        Image healthImage = healthCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>();
        prefab.transform.position = pos;
        rb = prefab.GetComponent<Rigidbody2D>();
        mono = prefab.GetComponent<EnemyMono>();
        mono.Damage = data.damage;
        health = new Health(data.health);
        new HealthView(health, healthImage, data.health);
    }

    public void Died()
    {
        RemoveModel?.Invoke(this);
    }
}
