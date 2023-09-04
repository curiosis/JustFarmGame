using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public readonly InventoryItemList[] ToolbarItems = new InventoryItemList[6];
    public List<InventoryItemList> InventoryItems;

    public int activeSlot = 1;

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        var temp = activeSlot;
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
        if (temp != activeSlot)
            RefreshToolbarItems();
        
    }
    
    private void RefreshToolbarItems()
    {
        for (int i = 0; i < InventoryItems.Count; i++)
        {
            if (InventoryItems[i].item.Toolkit && InventoryItems[i].item.ToolkitNum > 0)
            {
                ToolbarItems[InventoryItems[i].item.ToolkitNum] = InventoryItems[i];
            }
        }
    }

    [Serializable]
    public struct InventoryItemList
    {
        public Item item;
        public int amount;
    }

    
}

