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
    public bool Toolkit;
    public int FarmCoinValue;
    public string Type;
    public bool CanSell;
}
