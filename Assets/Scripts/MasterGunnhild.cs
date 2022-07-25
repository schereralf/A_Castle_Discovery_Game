using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

    // POLYMORPHISM  there are three master workmen in the game, each represents a different craft and is looking
    // for you to locate different tools on the abandoned castle premnises.
    public class MasterGunnhild : Master
    {
        public override void ThisMaster()
    {
        masterName = "Gunnhild the Trader";
        craftName = (ItemCraft)4;
    }
 
    }
