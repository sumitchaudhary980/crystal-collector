using UnityEngine;
using TMPro; // Required for TextMeshPro
public class GameManager : MonoBehaviour
{
    // Public variables — drag UI objects here in Inspector
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public GameObject winPanel;
    // Game settings
    public float timeLimit = 60f; // 60 second timer
                                  // Private tracking variables
    private int score = 0;
    private int totalCrystals;
    private float timeRemaining;
    private bool gameOver = false;
    // Static reference — other scripts can call GameManager.instance
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        // Count how many Crystal objects exist in the scene at start.
        totalCrystals = GameObject.FindGameObjectsWithTag("Crystal").Length;
        timeRemaining = timeLimit;
        winPanel.SetActive(false);
        UpdateUI();
    }
    void Update()
    {
        if (gameOver) return; // Stop everything if game is finished.
                              // Count down the timer.
        timeRemaining -= Time.deltaTime;
        // Clamp so it never goes below 0.
        if (timeRemaining < 0) timeRemaining = 0;
        UpdateUI();
        // Check for time-out loss condition.
        if (timeRemaining <= 0)
        {
            GameLost();
        }
    }
    // Called by Crystal.cs when a crystal is collected.
    public void CrystalCollected()
    {
        score++;
        UpdateUI();
        if (score >= totalCrystals)
        {
            GameWon();
        }
    }
    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + Mathf.RoundToInt(timeRemaining);
    }
    void GameWon()
    {
        gameOver = true;
        winPanel.SetActive(true);
    }
    void GameLost()
    {
        gameOver = true;
        // We'll add a proper Game Over screen in Week 5.
        Debug.Log("Time's up! Game Over.");
    }
}
