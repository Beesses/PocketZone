using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "Data/Inventory")]
public sealed class InventoryData : BaseData
{
    public GameObject Slot;
    public List<ItemData> Items;
    public List<int> Num;
}
