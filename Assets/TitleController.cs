using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public Button bLevels;
    public Button bCredits;
    public Button bEasy;
    public Button bMedium;
    public Button bHard;
    public Button bBackA;
    public Button bBackB;

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

    void LevelSelectScreen()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
    }

    void CreditScreen()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(true);
    }

    void StartEasy()
    {
        SceneManager.LoadScene("EasyLevel", LoadSceneMode.Single);
    }

    void StartMedium()
    {
        SceneManager.LoadScene("MediumLevel", LoadSceneMode.Single);
    }

    void StartHard()
    {
        SceneManager.LoadScene("HardLevel", LoadSceneMode.Single);
    }

    void BackToStart()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(false);
    }


}
