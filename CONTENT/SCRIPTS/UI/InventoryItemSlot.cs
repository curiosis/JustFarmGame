using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private RawImage itemIcon;
    [SerializeField]
    private GameObject lockedIcon;
    [Header("Item Name PANEL")]
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private GameObject itemNameGO;
    [Header("Item Amount PANEL")]
    [SerializeField]
    private TextMeshProUGUI itemAmount;
    [SerializeField]
    private GameObject itemAmountGO;

    private InventoryUI inventoryUI;
    public InventoryManager.InventoryItemList ItemList { get; private set; }

    public void SetSlotValues(InventoryManager.InventoryItemList inventoryItem)
    {
        ItemList = inventoryItem;
        itemName.text = inventoryItem.item.Name;
        itemIcon.texture = inventoryItem.item.Icon.texture;
        lockedIcon.SetActive(inventoryItem.item.ToolkitNum > 0);
        if (ItemList.item.MaxStack == 1)
        {
            itemAmountGO.SetActive(false);
        }
        else
        {
            itemAmountGO.SetActive(true);
            itemAmount.text = $"x{inventoryItem.amount}";
        }
            
    }

    public void RemoveSlotValues()
    {
        itemAmount.text = "";
        itemIcon = null;
    }

    public void SetInventoryUI(InventoryUI newInventoryUI)
    {
        inventoryUI = newInventoryUI;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!itemNameGO.activeSelf && !string.IsNullOrEmpty(itemName.text))
            itemNameGO.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemNameGO.activeSelf)
            itemNameGO.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            var tempRectPos = this.gameObject.GetComponent<RectTransform>().position;
            tempRectPos.x += 120.0f;
            inventoryUI.SetItemPanel(tempRectPos, ItemList);
            inventoryUI.SetItemPanel(true);
        }
        else
        {
            inventoryUI.SetItemPanel(false);
        }
    }
}
