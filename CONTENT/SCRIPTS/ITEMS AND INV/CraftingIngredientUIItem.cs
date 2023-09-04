using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingIngredientUIItem : MonoBehaviour
{
    [SerializeField]
    private RawImage icon;
    [SerializeField]
    private TextMeshProUGUI amount;

    public void SetIngredientUI(InventoryManager.InventoryItemList ingredient)
    {
        icon.texture = ingredient.item.Icon.texture;
        amount.text = ingredient.amount.ToString();
    }
}