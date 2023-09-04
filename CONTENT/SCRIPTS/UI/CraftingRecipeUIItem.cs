using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CraftingRecipeUIItem : MonoBehaviour
{
    [Header("Result")]
    [SerializeField]
    private RawImage icon;
    [SerializeField]
    private TextMeshProUGUI amount;
    [Space]
    [Header("Ingredients")]
    [SerializeField]
    private GameObject ingredientItemArea;
    [SerializeField]
    private GameObject ingredientItem;

    private List<CraftingIngredientUIItem> craftingIngredientUIItems;

    public void SetRecipeUI(RecipeCrafting recipe)
    {
        icon.texture = recipe.result.item.Icon.texture;
        amount.text = recipe.result.amount.ToString();
        for (int i=0; i<recipe.ingredients.Count; i++)
        {
            var obj = Instantiate(ingredientItem, ingredientItemArea.transform);
            var objComponent = obj.GetComponent<CraftingIngredientUIItem>();
            craftingIngredientUIItems.Add(objComponent);
            objComponent.SetIngredientUI(recipe.ingredients[i]);
        }
    }
}
