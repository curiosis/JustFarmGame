using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    [SerializeField]
    private GameObject recipeItem;
    [SerializeField]
    private GameObject recipesArea;

    private List<RecipeCrafting> recipes;
    private readonly List<CraftingRecipeUIItem> craftingRecipesUI;

    private void OnEnable()
    {
        recipes.Clear();
        recipes = ItemDatabase.Instance.Recipes;
        for (int i=0; i<recipes.Count; i++)
        {
            var obj = Instantiate(recipeItem, recipesArea.transform);
            var objComponent = obj.GetComponent<CraftingRecipeUIItem>();
            craftingRecipesUI.Add(objComponent);
            objComponent.SetRecipeUI(recipes[i]);
        }
    }

    private void OnDisable()
    {
        
    }
}
