
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName="New Inventory", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    //Here we save the collected items that we have already - literally - run across in case we want to pick up game later on.
    //Point is to explore castle and surroundings.  Next level we plan to discover an ox-cart + team of workmen + start building something.

    public string savePath;
    public ItemDatabaseObject database;
    public Inventory Container;

    private void OnEnable()
    {
#if UNITY_EDITOR 
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
#else
        database = Resources.Load<ItemDatabaseObject>("Database");
#endif
    }

    public void AddItem(Item _item, int _amount)
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            if (Container.Items[i].item.Id == _item.Id)
            {
                Container.Items[i].AddAmount(_amount);
                return;
            }
        }
        Container.Items.Add(new InventorySlot(_item.Id,_item, _amount));
    }
    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Container = (Inventory)formatter.Deserialize(stream);
            stream.Close();
        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    { }
}
[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new();
}

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;
    public int ID;

    //ENCAPSULATION
    //Each feature of an InventorySlot is available for use elsewhere but these features cannot be changed 
    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
