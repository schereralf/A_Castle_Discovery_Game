using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName="New Inventory", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    //Here we save the collected items that we have already - literally - run across in case we want to pick up game later on.
    //Point is to explore castle and surropounding.  Next level we plan to discover an ox cart and a team of workmen and start building something.

    public string savePath;
    private ItemDatabaseObject database;
    public List<InventorySlot> Container = new();

    private void OnEnable()
    {
#if UNITY_EDITOR 
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Scriptable Objects/Items/Database.asset", typeof(ItemDatabaseObject));
#else
        database = Resources.Load<ItemDatabaseObject>("Database");
#endif
    }

    public void AddItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                return;
            }
        }

        Container.Add(new InventorySlot(database.getID[_item],_item, _amount));
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new();

        Debug.Log(Application.persistentDataPath + savePath);

        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new();

            Debug.Log("filepath to load" + Application.persistentDataPath + savePath);

            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
        else { Debug.Log("Not Founde"); }
    }

    public void OnAfterDeserialize()
    {

        Debug.Log("number of items"+Container.Count);

        for(int i=0; i<Container.Count; i++) 
        {
            Container[i].item = database.getItem[Container[i].ID];
        }
    }

    public void OnBeforeSerialize()
    {
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public int ID;
    public InventorySlot(int _id, ItemObject _item, int _amount)
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
