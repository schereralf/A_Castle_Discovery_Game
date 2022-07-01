
using UnityEngine;

public enum ItemType 
{
Substances,
Workmen,
Equipment
}

// ABSTRACTION
// There are three types of itemtypes.  Common to each one is a description, a type, and a prefab.
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}
