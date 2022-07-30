
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Our player collects an inventory of discovered items during the game.
    //Items can be either construction materials or construction tools.
    //Will add Workmen as a third category eventually.

    public InventoryObject Inventory;

    // Most of the player code of course deals with the character controller
    // since the castle where items are hidden contains a LOT of stairs, a character controller
    // appeared more reasonable than a player controller.
    
    private GameManager gameManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI narrateText;
    public int score;
    private string narrate;
    private readonly float speed = 15.0f;
    private readonly float jumpSpeed = 10.0f;
    private float horizontalInput;
    private float forwardInput;
    public CharacterController controller;
    public Vector3 move;
    private Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;
    private bool ole_done = false;
    private bool axl_done = false;
    private bool sverker_done = false;
    private bool gunnhild_done = false;
    private bool olav_done = false;
    private bool thoralf_done = false;

    public List<AudioClip> chimes = new List<AudioClip>();
    public AudioSource source;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

        public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        var masteraxl = other.GetComponent<MasterAxl>();
        var mastersverker = other.GetComponent<MasterSverker>();
        var masterole = other.GetComponent<MasterOle>();
        var mastergunnhild = other.GetComponent<MasterGunnhild>();
        var masterolav = other.GetComponent<MasterOlav>();
        var masterthoralf = other.GetComponent<MasterThoralf>();

        if (item!=null)
        {
            Inventory.AddItem(item.item, 1);
            CheckScore();
            narrate = item.item.name+". "+item.item.description;
            narrateText.text = "Last discovered item: " + narrate;
            source.PlayOneShot(chimes[(Random.Range(0, chimes.Count))]);
            Destroy(other.gameObject);
        }

        if (masteraxl)
        {
            if (!axl_done) axl_done = true;
            CheckScore();
            masteraxl.CheckProgress(Inventory, score );
        }

        if (mastersverker)
        {
            if (!sverker_done) sverker_done = true;
            CheckScore();
            mastersverker.CheckProgress(Inventory, score);
        }

        if (masterole)
        {
            if (!ole_done) ole_done = true;
            CheckScore();
            masterole.CheckProgress(Inventory, score);
        }

        if (mastergunnhild)
        {
            if (!gunnhild_done) gunnhild_done = true;
            CheckScore();
            mastergunnhild.CheckProgress(Inventory, score);
        }

        if (masterolav)
        {
            if (!olav_done) olav_done = true;
            CheckScore();
            masterolav.CheckProgress(Inventory, score);
        }

        if (masterthoralf)
        {
            if (!thoralf_done) thoralf_done = true;
            CheckScore();
            masterthoralf.CheckProgress(Inventory, score);
        }
    }

    public void CheckScore()
    {
        score = Inventory.Container.Count;
        if (axl_done) score += 5;
        if (ole_done) score += 5;
        if (sverker_done) score += 5;
        if (gunnhild_done) score += 5;
        if (olav_done) score += 5;
        if (thoralf_done) score += 5;
        scoreText.text = "Score: " + score;
    }

    public void OnTriggerExit(Collider other)
    {
        var master = other.GetComponent<Master>();

        if (master)
        {
            master.SwitchOffMessage();
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

        // Move the player forward  

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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameManager.SaveScore(score);
            gameManager.GameOver();
        }
    }
  
    private void OnApplicationQuit()
    {
        Inventory.Container.Clear();
    }
}