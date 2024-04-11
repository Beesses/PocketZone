using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Data/Items")]
public class ItemsData : ScriptableObject
{
    public List<ItemData> Items;
}
