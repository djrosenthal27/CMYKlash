using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPowerup : MonoBehaviour
{
    public TMP_Text powerupText;
    bool powerupActivated;

    public void Display(string display)
    {
        //score = score + updateMultiplier.multiplier;
        this.gameObject.GetComponent<TextMeshProUGUI>().text = display;
    }
}
