using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Handles UI display for powerups
public class DisplayPowerup : MonoBehaviour
{

    // Sets the Powerup Text to describe the currently activate powerup
    public void Display(string textToDisplay)
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = textToDisplay;
    }
}
