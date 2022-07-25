using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TradingGood", menuName = "Inventory System/Items/TradingGoods")]
public class TradingGoods : ItemObject
{
    // INHERITANCE
    //Trading goods are required for construction projects and they only have one important attribute: their cost, i.e. scarcity value

    public int costPerModus; 
    public void Awake()
    {
        type = ItemType.TradingGoods;
    }
}
