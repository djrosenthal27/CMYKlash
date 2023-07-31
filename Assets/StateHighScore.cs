using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateHighScore : MonoBehaviour
{
    public string level;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt(level);
    }

}
