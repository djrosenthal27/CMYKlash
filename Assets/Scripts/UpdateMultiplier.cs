using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateMultiplier : MonoBehaviour
{
    public TMP_Text multiplierText;
    public int multiplier;
    int kills;
    // Start is called before the first frame update
    void Start()
    {
        multiplier = 1;
        kills = 0;
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Multiplier: 1";
    }

    void ChangeMultiplier()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Multiplier: " + multiplier;
    }

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
