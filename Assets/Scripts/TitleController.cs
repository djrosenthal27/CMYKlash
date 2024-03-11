using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Controls the title, level select, and credit screen functionality
public class TitleController : MonoBehaviour
{
    public Button bLevels;
    public Button bCredits;
    public Button bEasy;
    public Button bMedium;
    public Button bHard;
    public Button bBackA;
    public Button bBackB;

    // Sets button functionalities for all buttons in the scene
    void Start()
    {
        bLevels.onClick.AddListener(LevelSelectScreen);
        bCredits.onClick.AddListener(CreditScreen);
        bEasy.onClick.AddListener(StartEasy);
        bMedium.onClick.AddListener(StartMedium);
        bHard.onClick.AddListener(StartHard);
        bBackA.onClick.AddListener(BackToStart);
        bBackB.onClick.AddListener(BackToStart);
    }

    // Deactivates title screen buttons and activates level select buttons
    void LevelSelectScreen()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
    }

    // Deactivates title screen buttons and activates credit screen panel and buttons
    void CreditScreen()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(true);
    }

    // Loads easy level
    void StartEasy()
    {
        SceneManager.LoadScene("EasyLevel", LoadSceneMode.Single);
    }

    // Loads medium level
    void StartMedium()
    {
        SceneManager.LoadScene("MediumLevel", LoadSceneMode.Single);
    }

    // Loads hard level
    void StartHard()
    {
        SceneManager.LoadScene("HardLevel", LoadSceneMode.Single);
    }

    // Deactivates level select buttons and credit screen button and panel. Activates title screen buttons
    void BackToStart()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(false);
    }


}
