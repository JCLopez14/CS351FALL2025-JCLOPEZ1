using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public bool gameOver = false;
    public bool won = false;
    public int score = 0;

    public TMP_Text textbox;
    public int scoreToWin;

    private int lastScore = -1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        gameOver = false;
        won = false;
        score = 0;

        if (textbox != null)
        {
            UpdateScoreText();
        }
    }

    void Update()
    {
        if (textbox == null) return;

        if (!gameOver)
        {
            // Update score text when score changes
            if (score != lastScore)
            {
                UpdateScoreText();
                lastScore = score;

                if (score >= scoreToWin)
                {
                    won = true;
                    gameOver = true;
                    UpdateScoreText();
                }
            }
        }
        else
        {
            // When game over, keep updating the text to ensure it shows
            UpdateScoreText();
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateScoreText()
    {
        if (textbox == null) return;

        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }
        else if (won)
        {
            textbox.text = "You win!\nPress R to Try Again!";
        }
        else
        {
            textbox.text = "You lose!\nPress R to Try Again!";
        }
    }
}














