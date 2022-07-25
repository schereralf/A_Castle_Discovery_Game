using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterThoralf: Master
{
    // POLYMORPHISM  there are three master tradesmen in the game, each represents a different craft and is looking
    // for you to locate different tools on the abandoned castle premnises.
    public override void ThisMaster()
    {
        masterName = "Thoralf the Farmer";
        craftName = (ItemCraft)3;
    }
}

