
public class MasterAxl : Master
{
    // POLYMORPHISM  there are three master workmen in the game, each represents a different craft and is looking
    // for you to locate different tools on the abandoned castle premnises.

    public override void ThisMaster()
    {
        masterName = "Axl the Mason";
        craftName = (ItemCraft)1;
    }
}
