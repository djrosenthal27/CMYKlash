using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HandlePause : MonoBehaviour
{
    public GameObject boundaryPiece;
    public Button bPause;
    public Button bResume;
    public Button bRestart;
    public Button bMenu;
    public GameObject scoreText;
    public string level;
    // Start is called before the first frame update
    void Start()
    { 
        transform.GetChild(4).gameObject.GetComponent<RawImage>().color = boundaryPiece.GetComponent<SpriteRenderer>().color;
        bPause.onClick.AddListener(Pause);
        bResume.onClick.AddListener(Resume);
        bRestart.onClick.AddListener(Restart);
        bMenu.onClick.AddListener(Menu);
    }

    void Pause()
    {
        Time.timeScale = 0;
        transform.GetChild(4).gameObject.SetActive(true);
    }

    void Resume()
    {
        Time.timeScale = 1;
        transform.GetChild(4).gameObject.SetActive(false);
    }

    void Restart()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt(level) < scoreText.GetComponent<UpdateScore>().GetScore())
        {
            PlayerPrefs.SetInt(level, scoreText.GetComponent<UpdateScore>().GetScore());
        } 
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }

    void Menu()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt(level) < scoreText.GetComponent<UpdateScore>().GetScore())
        {
            PlayerPrefs.SetInt(level, scoreText.GetComponent<UpdateScore>().GetScore());
        }
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

}
