using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Handles the Pause Menu UI
public class HandlePause : MonoBehaviour
{
    public GameObject boundaryPiece;
    public Button bPause;
    public Button bResume;
    public Button bRestart;
    public Button bMenu;
    public GameObject scoreText;
    public string level;

    // Makes the pause menu's color the same as the screen border's color, and adds listeners to UI buttons
    void Start()
    { 
        transform.GetChild(4).gameObject.GetComponent<RawImage>().color = boundaryPiece.GetComponent<SpriteRenderer>().color;
        bPause.onClick.AddListener(Pause);
        bResume.onClick.AddListener(Resume);
        bRestart.onClick.AddListener(Restart);
        bMenu.onClick.AddListener(Menu);
    }

    // Pauses the game and brings up the pause menu
    void Pause()
    {
        Time.timeScale = 0;
        transform.GetChild(4).gameObject.SetActive(true);
    }

    // Resumes the game and removes the pause menu
    void Resume()
    {
        Time.timeScale = 1;
        transform.GetChild(4).gameObject.SetActive(false);
    }

    // Restarts the scene
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

    // Goes to the menu scene
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
