using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public sealed class PlayerModel
{
    private GameObject prefab;
    private Rigidbody2D rb;
    private PlayerMono mono;
    private InputActionReference joystick;
    private InputActionReference attack;
    private float speed;
    private float damage;
    private Health health;
    private int bulletCapacity;
    public int currentBullets;

    public GameObject Prefab { get { return prefab; } }
    public Health MyHealth{ get { return health; } }
    public float Speed { get { return speed; } }
    public float Damage { get { return damage; } }
    public Rigidbody2D RB { get { return rb; } }
    public InputActionReference Joystick { get { return joystick; } }
    public InputActionReference Attack { get { return attack; } }
    public PlayerMono Mono { get { return mono; } }
    public int BulletCapacity { get { return bulletCapacity; } set { bulletCapacity = value; } }
    public PlayerModel(PlayerData data)
    {
        speed = data.speed;
        damage = data.damage;
        bulletCapacity = data.bulletCapacity;
        prefab = GameObject.Instantiate(data.prefab);
        GameObject healthCanvas = GameObject.Instantiate(data.HelathCanvas);
        healthCanvas.transform.SetParent(prefab.transform);
        Image healthImage = healthCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>();
        joystick = data.joystick;
        attack = data.attack;
        mono = prefab.GetComponent<PlayerMono>();
        rb = prefab.GetComponent<Rigidbody2D>();
        health = new Health(data.health);
        new HealthView(health, healthImage, data.health);
        currentBullets = bulletCapacity;
    }
}
