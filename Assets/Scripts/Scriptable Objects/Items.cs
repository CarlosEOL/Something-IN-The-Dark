using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject
{
    public string itemName = "New Item";
    public string itemDescription = "New Description";
    public Sprite icon;
    public enum Type
    {
        Default, Consumable, Weapon, Ammunition
    }
    public Type type = Type.Default;
}
