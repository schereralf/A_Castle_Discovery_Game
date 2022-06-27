using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item Database",menuName ="Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;
    public Dictionary<ItemObject, int> getID = new();
    public Dictionary<int, ItemObject> getItem = new();

    public void OnAfterDeserialize()
    {
        getID = new Dictionary<ItemObject, int>();
        getItem = new Dictionary<int, ItemObject>();
        for (int i = 0; i < Items.Length; i++) 
        {
            getID.Add(Items[i],i);
            getItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {     
    }
}
