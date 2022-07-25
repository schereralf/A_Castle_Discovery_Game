
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI completedGameText;  

    public Button exitGameButton;
    public Button startGameButton;
    public GameObject player;
    public Camera startEndCamera;
    public Camera playerCamera;
    public bool isGameActive;
    public GameObject titleScreen;
    public Time starttime;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera.gameObject.SetActive(false);
        playerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        scoreText.gameObject.SetActive(false);
        completedGameText.gameObject.SetActive(false);  
    }

    public void SaveScore(int score)
    {
        CastleGameManager.Instance.AddSession(score);
        CastleGameManager.Instance.SaveNames();
    }

    public void GameOver()
    {
        isGameActive = false;
        playerCamera.gameObject.SetActive(false);
        playerCamera.enabled = false;
        startEndCamera.gameObject.SetActive(true);
        startEndCamera.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        exitGameButton.gameObject.SetActive(true);
        startGameButton.gameObject.SetActive(true);
        introText.gameObject.SetActive(false);
        itemText.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        titleScreen.SetActive(true);
        exitGameButton.gameObject.SetActive(false);
        startGameButton.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        startEndCamera.gameObject.SetActive(false);
        startEndCamera.enabled = false;
        player.SetActive(true);
        playerCamera.gameObject.SetActive(true);
        playerCamera.enabled = true;
        scoreText.gameObject.SetActive(true);
        itemText.gameObject.SetActive(true);
        introText.text = "Save inventory for later = Keypad+   \n Retrieve saved inventory = Keypad Enter  \n Leave game early = Return";
    }
}

