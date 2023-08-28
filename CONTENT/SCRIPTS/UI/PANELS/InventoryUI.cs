using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject EmptySlot;
    [SerializeField]
    private Transform InventorySlots;

    [SerializeField]
    private GameObject itemPanel;
    

    // TEMP
    public int MaxInvSlots = 32;
    readonly List<InventoryItemSlot> inventoryItemSlots = new();
    public InventoryManager.InventoryItemList hoverItem;
    public List<InventoryManager.InventoryItemList> inventoryItems;

    private void Update()
    {
        if (hoverItem.item && !itemPanel.activeSelf)
            itemPanel.SetActive(true);
        else if (hoverItem.item == null && itemPanel.activeSelf)
            itemPanel.SetActive(false);
    }

    private void OnEnable()
    {
        inventoryItems = Player.Instance.InventoryManager.InventoryItems;

        for (int i = 0; i < 32; i++)
        {
            var tempSlot = Instantiate(EmptySlot, InventorySlots);
            inventoryItemSlots.Add(tempSlot.GetComponent<InventoryItemSlot>());
        }

        for (int i=0; i<inventoryItems.Count; i++)
        {
            inventoryItemSlots[i].SetInventoryUI(this);
            inventoryItemSlots[i].SetSlotValues(inventoryItems[i]);
        }
    }

    private void OnDisable()
    {
        foreach (InventoryItemSlot inventoryItemSlot in inventoryItemSlots)
        {
            if (inventoryItemSlot.gameObject != null)
            {
                inventoryItemSlot.RemoveSlotValues();
                Destroy(inventoryItemSlot.gameObject);
            }
        }
        inventoryItemSlots.Clear();
    }
}
