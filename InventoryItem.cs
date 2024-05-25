using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryItem 
{
    public ItemData data;
    public int stacksize;
    
    public InventoryItem(ItemData newData)
    {
        data = newData;
        AddStack();
    }
    public void AddStack()
    {
        stacksize++;
    }
    public void RemoveStack()
    {
        stacksize--;
    }
}
