
using UnityEngine;

public enum ItemType 
{
Substances,
Workmen,
Equipment
}

// There are three types of itemtypes.  Each one has a description, a type, and a prefab.
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}
