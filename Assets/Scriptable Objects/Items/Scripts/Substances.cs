using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Substance", menuName = "Inventory System/Items/Substances")]
public class Substances : ItemObject
{
    //Substances are required for construction projects and they only have one important attribute: their cost (i.e. scarcity value)

    public int costPerModus; 
    public void Awake()
    {
        type = ItemType.Substances;
    }
}
