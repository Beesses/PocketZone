using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Data/Player")]
public sealed class PlayerData : BaseEntityData
{
    public InputActionReference joystick;
    public InputActionReference attack;
    public int bulletCapacity;
    public GameObject HelathCanvas;
}
