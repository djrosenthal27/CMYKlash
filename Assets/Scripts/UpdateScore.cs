using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public UpdateMultiplier updateMultiplier;
    public float dotScoreCountdown;
    int score;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        score = 0;
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Score: 0";
    }

    public void ChangeScore()
    {
        score = score + updateMultiplier.multiplier;
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }

    void Update()
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Dot")
        {
            if (timer < dotScoreCountdown)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                ChangeScore();
                timer = 0;
            }
        }
    }
}
