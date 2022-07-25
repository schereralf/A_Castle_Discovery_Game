
using TMPro;
using UnityEngine;

public class Master : MonoBehaviour
{
    public TextMeshProUGUI completedGameText;
    public TextMeshProUGUI narrateText;
    public ItemDatabaseObject database;
    protected string masterName;
    protected ItemCraft craftName;
    protected int databaseItems = 0;
    private GameManager gameManager;
    private int mastercounter = 0;

    // Virtual method to show that you have entered a masters presence with progress report

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public virtual void ThisMaster()
    {
        masterName = "";
        craftName = (ItemCraft)2;
    }

    public void CheckProgress(InventoryObject ncollected, int score)
    {
        ThisMaster();
        var craftItems = ncollected.Container.FindAll(s => s.item.craft.Equals(craftName));
        foreach (var entry in database.Items) { if (entry.craft.Equals(craftName)) databaseItems++; }

        int uncollectedItems = databaseItems - craftItems.Count;
        if (uncollectedItems > 0)
        {
            narrateText.text = ("Master " + masterName + " says: Hello there.  I am a local community leader looking for items for my trade. I think there still are some items of interest to me here that I have not found yet. Please help me find " + uncollectedItems + " more items !!!");
        }
        else
        {
            narrateText.text = ("Master " + masterName + " says: Great, you are done with my part of this game. My work can begin! You have collected all of my " + databaseItems + " items!");
            mastercounter++;
            if (mastercounter>=3) 
            {
                completedGameText.gameObject.SetActive(true);
                gameManager.SaveScore(score);
                gameManager.GameOver();
            }
        }
        databaseItems = 0;
    }

    public void SwitchOffMessage()
    {
        narrateText.text = ("");
    }
}

