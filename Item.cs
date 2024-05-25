using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;
    public GameObject m_object;

    public void PickUp()
    {
        Debug.Log("PickUp method called.");
        if (Inventory.instance != null && itemData != null)
        {
            Debug.Log("Inventory instance and itemData are not null. Proceeding...");
            Inventory.instance.AddItem(itemData);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Inventory instance or itemData is null!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter method called.");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected. Picking up item...");
            PickUp();
        }
    }

}
