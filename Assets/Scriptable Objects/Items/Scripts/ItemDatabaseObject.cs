using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item Database",menuName ="Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;

    public Dictionary<int, ItemObject> getItem = new();

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Items.Length; i++) 
        {
            Items[i].Id = i;    
            getItem.Add(i, Items[i]);
        }
    }
    public void OnBeforeSerialize()
    {
        getItem = new Dictionary<int, ItemObject>();
    }
}
