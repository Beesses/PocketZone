using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class InventoryModel
{
    private GameObject prefab;
    private GameObject inventory;
    private Image[] slots;
    private TextMeshProUGUI[] textMesh;
    private Button[] btn;

    public GameObject Prefab { get { return prefab; } }

    public GameObject Inventory { get { return inventory; } }
    public Image[] Slots { get { return slots; } }
    public TextMeshProUGUI[] TextMesh { get { return textMesh; } }
    public Button[] Btn { get { return btn; } }

    public InventoryModel(InventoryData data)
    {
        slots = new Image[4];
        textMesh = new TextMeshProUGUI[4];
        btn = new Button[4];
        prefab = GameObject.Instantiate(data.prefab);
        inventory = prefab.transform.GetChild(0).gameObject;
        for(int i = 0; i < slots.Length; i++)
        {
            GameObject slot = GameObject.Instantiate(data.Slot);
            slot.gameObject.transform.SetParent(inventory.transform);
            slots[i] = slot.transform.GetChild(0).gameObject.GetComponent<Image>();
            textMesh[i] = slots[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            slots[i].color -= new Color(0f, 0f, 0f, 1f);
            btn[i] = slot.transform.GetChild(1).GetComponent<Button>();
        }

        for(int i = 0; i < data.Items.Capacity; i++)
        {
            slots[i].sprite = data.Items[i].sprite;
            slots[i].color += new Color(0f, 0f, 0f, 1f);
            textMesh[i].text = data.Num[i].ToString();
        }
    }
}
