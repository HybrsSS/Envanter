using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public Dictionary<ItemData,InventoryItem> inventoryDictionary = new Dictionary<ItemData,InventoryItem>();
    public Transform inventorySlot;
    public Item_UI[] itemSlot;


    private void Start()
    {
        itemSlot = inventorySlot.GetComponentsInChildren<Item_UI>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    public void AddItem(ItemData item)
    {
        if(inventoryDictionary.TryGetValue(item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(item);
            inventoryItems.Add(newItem);
            inventoryDictionary.Add(item, newItem);
        }
        UpdateUI();
    }
    public void RemoveItem(ItemData item)
    {
        if (inventoryDictionary.TryGetValue(item, out InventoryItem value))
        {
            if(value.stacksize<=1)
            {
                inventoryItems.Remove(value);
                inventoryDictionary.Remove(item);
            }
            else
            {
              value.RemoveStack();
            }
            UpdateUI();
        }
    }
    void UpdateUI()
    {
        int itemCount = inventoryItems.Count;

        // itemSlot dizisinin boyutunu kontrol edin ve inventoryItems listesinin eleman sayýsýna eþit hale getirin
        if (itemSlot.Length < itemCount)
        {
            Array.Resize(ref itemSlot, itemCount);
        }

        // Tüm envanter öðelerini döngüye alýn ve itemSlot dizisini güncelleyin
        for (int i = 0; i < itemCount; i++)
        {
            itemSlot[i].UpdateSlotsUI(inventoryItems[i]);
        }
    }
}
