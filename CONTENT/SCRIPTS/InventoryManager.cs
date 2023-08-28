using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> usableItems;

    public List<InventoryItemList> InventoryItems;

    public int activeSlot = 1;

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f)
        {
            if (scrollInput > 0f)
            {
                activeSlot = (activeSlot < 6) ? activeSlot + 1 : 1;
            }
            else if (scrollInput < 0f)
            {
                activeSlot = (activeSlot > 1) ? activeSlot - 1 : 6;
            }
        }
        foreach (GameObject gameObject in usableItems)
            gameObject.SetActive(false);
        usableItems[activeSlot - 1].SetActive(true);
    }

    [Serializable]
    public struct InventoryItemList
    {
        public Item item;
        public int amount;
    }

    
}

