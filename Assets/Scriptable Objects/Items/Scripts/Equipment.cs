
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory System/Items/Equipment")]
public class Equipment : ItemObject
    // INHERITANCE
    // Equipment comes with a construction bonus, and the substance that it is used with.
{
    public float constructionBonus;
    public Substances substance;
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}

