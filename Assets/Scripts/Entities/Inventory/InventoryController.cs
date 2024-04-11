using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController
{

    private InventoryModel model;

    public InventoryController()
    {
        model = new InventoryModel((InventoryData)AssetDatabase.LoadAssetAtPath("Assets/Data/Inventory.asset", typeof(InventoryData)));
        SetButtons();
    }

    private void SetButtons()
    {
        for(int i = 0; i < model.Slots.Length; i++)
        {
            Image img = model.Slots[i];
            TextMeshProUGUI txt = model.TextMesh[i];
            model.Btn[i].onClick.AddListener(() => deleteItem(img, txt));
        }
    }

    public void setItem(Sprite sprite)
    {
        for (int i = 0; i < model.Slots.Length; i++)
        {
            if(model.Slots[i].sprite == sprite)
            {
                if(model.TextMesh[i].text != "" && int.Parse(model.TextMesh[i].text) >= 2)
                {
                    model.TextMesh[i].text = (int.Parse(model.TextMesh[i].text) + 1).ToString();
                    return;
                }
                else
                {
                    model.TextMesh[i].text = "2";
                    return;
                }
            }
        }
        for (int i = 0; i < model.Slots.Length; i++)
        {
            if(model.Slots[i].sprite == null)
            {
                model.Slots[i].sprite = sprite;
                model.Slots[i].color += new Color(0f, 0f, 0f, 1f);
                return;
            }
        }
        Debug.Log("Inventory is full");
    }

    public void deleteItem(Image sprite, TextMeshProUGUI text)
    {
        sprite.sprite = null;
        sprite.color -= new Color(0f, 0f, 0f, 1f);
        text.text = "";
    }
}
