using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Handles the High Score text on the level select screen
public class StateHighScore : MonoBehaviour
{
    public string level;

    // Prints out the level high score for each level on the level select screen, as saved in player's platform registry
    void Start()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt(level);
    }

}
