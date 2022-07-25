
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons", menuName = "Inventory System/Items/Weapons")]
public class Weapons : ItemObject
{
    // INHERITANCE 
    //Weapon prefabs
    //Weapons have defense and attack factors for combat. 

    public float attackFactor;
    public float defenseFactor;
    public void Awake()
    {
        type = ItemType.Weapons;
    }
}
