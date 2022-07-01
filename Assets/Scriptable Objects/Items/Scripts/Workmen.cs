
using UnityEngine;

[CreateAssetMenu(fileName = "New Workmen", menuName = "Inventory System/Items/Workmen")]
public class Workmen : ItemObject
{
    // INHERITANCE 
    //Workmen prefabs are not added yet (they will come from a set of 3D models of medieval construction workers that I created last year)
    //Workers have skills indicating which substance they work with what their salary is and how fast they can work. 

    public float constructionSpeed;
    public Substances worksWith;
    public float salaryPerDay;
    public void Awake()
    {
        type = ItemType.Workmen;
    }
}
