
using UnityEngine;

public enum ItemType 
{
Substances,
Workmen,
Equipment,
TradingGoods,
Weapons,
}

public enum ItemCraft
{
    Carpenter,
    Mason,
    Smith,
    Farmer,
    Trader,
    Guard
}

// ABSTRACTION
// There are five sorts of itemtypes in the game.  Common to each one is a description, a type, and a prefab.
public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    public ItemCraft craft;
    [TextArea(15,20)]
    public string description;
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public ItemCraft craft;
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;
        craft = item.craft;
    }
}
