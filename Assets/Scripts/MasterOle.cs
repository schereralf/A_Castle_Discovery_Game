
public class MasterOle : Master
{
    // POLYMORPHISM  there are three master workmen in the game, each represents a different craft and is looking
    // for you to locate different tools on the abandoned castle premnises.

    public override void ThisMaster()
    {
        masterName = "Ole the Smith";
        craftName = (ItemCraft)2;
    }
}
