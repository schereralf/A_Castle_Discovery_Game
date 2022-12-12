
public class MasterOlav : Master
{ 
    // POLYMORPHISM  there are three master craftsmen in the game, each represents a different craft and is looking
    // for you to locate different tools on the abandoned castle premnises.

    public override void ThisMaster()
    {
        masterName = "Olav the Guard";
        craftName = (ItemCraft)5;
    }
}
