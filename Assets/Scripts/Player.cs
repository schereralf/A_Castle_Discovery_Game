
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Our player collects an inventory of discovered items during the game.
    //Items can be either construction materials or construction tools.
    //Will add Workmen as a third category soon.

    public InventoryObject Inventory;

    // Most of the player code of course deals with the Character controller
    // since the castle where items are hidden contains a LOT of stairs, a Character Controller
    // appeared more reasonable than a Player controller.

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI narrateText;
    private int score;
    private string narrate;
    private readonly float speed = 15.0f;
    private readonly float jumpSpeed = 10.0f;
    private float horizontalInput;
    private float forwardInput;
    public CharacterController controller;
    private Vector3 move;
    private Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();

        if (item)
        {
            Inventory.AddItem(item.item, 1);
            score = Inventory.Container.Count;
            narrate = item.item.name+". "+item.item.description;
            scoreText.text = "Score: " + score +" discovered item types";
            narrateText.text = "Last discovered item: " + narrate;
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame.  Here we do basic movement including jumps, but also we have opportunity to save inventory status
    // with discovered items for a future session.

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the player Forward  

        move = transform.right * horizontalInput + transform.forward * forwardInput;
        controller.Move(speed * Time.deltaTime * move);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Inventory.Save();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Inventory.Load();
        }
    }
  
    private void OnApplicationQuit()
    {
        Inventory.Container.Clear();
    }
}