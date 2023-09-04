using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    [SerializeField]
    private List<Item> items;

    public List<RecipeCrafting> Recipes;

    private static ItemDatabase itemDatabase;

    public static ItemDatabase Instance
    {
        get => itemDatabase;
    }

    private void Awake()
    {
        if (!itemDatabase)
            itemDatabase = FindObjectOfType<ItemDatabase>();
    }

    public Item GetItemBy(int id)
    {
        return items.Find(item => item.ID == id);
    }
    public Item GetItemBy(string name)
    {
        return items.Find(item => item.Name == name);
    }
    public List<Item> GetToolbarItems(bool isToolkbar)
    {
        return items.FindAll(item => item.Toolkit == isToolkbar);
    }
    public List<Item> GetUseableItems(bool isUseable)
    {
        return items.FindAll(item => item.IsUsable == isUseable);
    }
    public List<Item> GetReadableItems(bool isReadable)
    {
        return items.FindAll(item => item.IsReadable == isReadable);
    }
    public List<Item> GeItemsByType(string type)
    {
        return items.FindAll(item => item.Type == type);
    }
    public List<Item> GetCanSellItems(bool canSell)
    {
        return items.FindAll(item => item.Name == name);
    }
}
