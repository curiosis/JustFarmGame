using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{
    public int ID;
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool IsUsable;
    public bool IsReadable;
    public bool IsDroppable;
    public int MaxStack;
    public bool CanDel;
    public bool Toolkit;
    public int ToolkitNum;
    public int FarmCoinValue;
    public string Type;
    public bool CanSell;

    public void SetItemToToolkit(int toolkitNum)
    {
        ToolkitNum = toolkitNum;
    }
}
