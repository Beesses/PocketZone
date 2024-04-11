using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemModel
{
    private GameObject prefab;

    public GameObject Prefab { get { return prefab; } }

    public ItemModel(Transform pos)
    {
        ItemsData ItemsData = (ItemsData)AssetDatabase.LoadAssetAtPath("Assets/Data/Items/Items.asset", typeof(ItemsData));
        ItemData data = ItemsData.Items[Random.Range(0, ItemsData.Items.Capacity)];
        prefab = GameObject.Instantiate(data.prefab);
        prefab.GetComponent<SpriteRenderer>().sprite = data.sprite;
        prefab.GetComponent<ItemMono>().ItemSprite = data.sprite;
        prefab.transform.position = pos.position;
    }
}
