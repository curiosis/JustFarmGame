using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Recipe")]
public class RecipeCrafting : ScriptableObject
{
    public InventoryManager.InventoryItemList result;
    public List<InventoryManager.InventoryItemList> ingredients;
}
