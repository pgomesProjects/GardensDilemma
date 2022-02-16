using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    public static bool isPaused;
    public static bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("LevelBGM", PlayerPrefs.GetFloat("MusicVol"));
        isPaused = false;
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameActive && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)))
        {
            if (!isPaused)
                Pause();
            else
                Unpause();
        }
        //If the game is not active and the game has not been won, it is a game over
        else if(!isGameActive && !TimerUntilMain.isWon)
        {
            FindObjectOfType<AudioManager>().Stop("LevelBGM");
            gameOverMenu.SetActive(true);
        }
    }
    public void Pause()
    {
        FindObjectOfType<AudioManager>().Pause("LevelBGM");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }//end of Pause

    public void Unpause()
    {
        FindObjectOfType<AudioManager>().Resume("LevelBGM");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }//end of Unpause

    public void RetryGame()
    {
        //Goes to main level
        FindObjectOfType<AudioManager>().ChangePitch("LevelBGM", 1.0f);
        FindObjectOfType<AudioManager>().Stop("LevelBGM");
        SceneManager.LoadScene("MainLevel");
    }//end of RetryGame

    public void ReturnMenu()
    {
        //Goes to main menu
        FindObjectOfType<AudioManager>().ChangePitch("LevelBGM", 1.0f);
        FindObjectOfType<AudioManager>().Stop("LevelBGM");
        SceneManager.LoadScene("MainMenu");
    }//end of ReturnMenu

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }//end of QuitGame
}
