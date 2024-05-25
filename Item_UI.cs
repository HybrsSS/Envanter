using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_UI : MonoBehaviour
{
    public Image itemImage;
    public Text itemAmount;
    public InventoryItem item;
   
    public void UpdateSlotsUI(InventoryItem newItem)
    {
        item = newItem;
        if(item != null)
        {
            itemImage.sprite = item.data.itemIcon;
            if(item.stacksize > 1 )
            {
                itemAmount.text = item.stacksize.ToString();
            }
            else
            {
                itemAmount.text = "";
            }
        }
        


       
    }
    
    
}
