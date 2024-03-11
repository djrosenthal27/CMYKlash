using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Handles the player's score and score text
public class UpdateScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public UpdateMultiplier updateMultiplier;
    public float dotScoreCountdown;
    int score;
    float timer;
    
    // Initializes the timer, score, and score text
    void Start()
    {
        timer = 0;
        score = 0;
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Score: 0";
    }

    // Increases the player's score by the multiplier and updates the score text to match
    public void ChangeScore()
    {
        score = score + updateMultiplier.multiplier;
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }

    // Updates the player's score when they are a Dot
    void Update()
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Dot")
        {
            // If player is a dot and timer hasn't reached countdown, increment timer
            if (timer < dotScoreCountdown)
            {
                timer = timer + Time.deltaTime;
            }
            // If player is a dot and timer has reached countdown, reset timer and increment score
            else
            {
                ChangeScore();
                timer = 0;
            }
        }
    }

    // Return the player's score
    public int GetScore()
    {
        return score;
    }
}
