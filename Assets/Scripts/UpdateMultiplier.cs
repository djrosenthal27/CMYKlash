using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Updates the multiplier which determines how many points the player gets
public class UpdateMultiplier : MonoBehaviour
{
    public TMP_Text multiplierText;
    public int multiplier;
    int kills;
    
    // Initializes kills and multiplier
    void Start()
    {
        multiplier = 1;
        kills = 0;
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Multiplier: 1";
    }

    // Updates multiplier text
    void ChangeMultiplier()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Multiplier: " + multiplier;
    }

    // Increases the kills, and for every 10 kills, increastes the multiplier
    public void IncreaseKill()
    {
        kills++;
        if (kills%10 == 0)
        {
            multiplier++;
            ChangeMultiplier();
        }
    }
}
