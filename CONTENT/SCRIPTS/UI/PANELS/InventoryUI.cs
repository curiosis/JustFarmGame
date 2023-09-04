using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject EmptySlot;
    [SerializeField]
    private Transform InventorySlots;
    [SerializeField]
    private List<InventoryUsableItemUI> inventoryUseableItemSlots;

    [Header("Add. ITEM PANEL")]
    [SerializeField]
    private RectTransform itemPanel;
    [SerializeField]
    private Button useButton;
    [SerializeField]
    private Button setButton;
    [SerializeField]
    private Button dropButton;
    [SerializeField]
    private Button infoButton;
    [SerializeField]
    private Button readButton;
    [SerializeField]
    private Button delButton;
    [SerializeField]
    private TextMeshProUGUI itemName;

    Vector2 mousePositionScreen;
    private InventoryManager.InventoryItemList activeItem;

    // TEMP
    public int MaxInvSlots = 32;
    readonly List<InventoryItemSlot> inventoryItemSlots = new();
    
    public InventoryManager.InventoryItemList hoverItem;
    public List<InventoryManager.InventoryItemList> inventoryItems;
    public List<InventoryManager.InventoryItemList> toolbarItems;

    public void SetItemPanel(bool isActive)
    {
        itemPanel.gameObject.SetActive(isActive);
    }

    public void SetButton()
    {
        activeItem.item.ToolkitNum = Player.Instance.InventoryManager.activeSlot;
        Refresh();
    }

    private void Update()
    {
        foreach (InventoryUsableItemUI usableItems in inventoryUseableItemSlots)
            usableItems.ChangeSelectorState(false);
        inventoryUseableItemSlots[Player.Instance.InventoryManager.activeSlot - 1].ChangeSelectorState(true);
    }

    public void SetItemPanel(Vector3 pos, InventoryManager.InventoryItemList item)
    {
        activeItem = item;
        itemPanel.position = pos;
        foreach (Transform childTransform in itemPanel)
        {
            childTransform.gameObject.SetActive(false);
        }

        if (item.item.IsUsable)
        {
            useButton.gameObject.SetActive(true);
            
        }
        if (item.item.Toolkit)
        {
            setButton.gameObject.SetActive(true);
            setButton.onClick.AddListener(SetButton);
        }
        if (item.item.IsReadable)
            readButton.gameObject.SetActive(true);
        infoButton.gameObject.SetActive(true);
        if (item.item.IsDroppable)
            dropButton.gameObject.SetActive(true);
        if (item.item.CanDel)
            delButton.gameObject.SetActive(true);

        var tempH = 0.0f;

        foreach (Transform childTransform in itemPanel)
        {
            if (childTransform.gameObject.activeSelf)
                tempH += 35.0f;
        }
        itemPanel.sizeDelta = new Vector2(itemPanel.sizeDelta.x, tempH);
        Debug.LogError(tempH);
    }

    private void OnEnable()
    {
        StartPanel();
    }

    private void OnDisable()
    {
        EndPanel();
    }

    private void Refresh()
    {
        EndPanel();
        StartPanel();
    }

    private void StartPanel()
    {
        inventoryItems = Player.Instance.InventoryManager.InventoryItems;
        toolbarItems = new List<InventoryManager.InventoryItemList>(Player.Instance.InventoryManager.ToolbarItems);

        for (int i = 0; i < 32; i++)
        {
            var tempSlot = Instantiate(EmptySlot, InventorySlots);
            inventoryItemSlots.Add(tempSlot.GetComponent<InventoryItemSlot>());
        }

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            inventoryItemSlots[i].SetInventoryUI(this);
            inventoryItemSlots[i].SetSlotValues(inventoryItems[i]);
            if (inventoryItems[i].item.Toolkit && inventoryItems[i].item.ToolkitNum > 0)
            {
                inventoryUseableItemSlots[inventoryItems[i].item.ToolkitNum - 1].SetIcon(inventoryItems[i].item.Icon);
            }
        }


        for (int i=0; i<6; i++)
        {

        }
    }

    private void EndPanel()
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
