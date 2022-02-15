using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameObject pauseMenu;

    public static bool isPaused;
    public static bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("LevelBGM", 1.0f);
        isPaused = false;
        pauseMenu.SetActive(false);
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
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }//end of Pause

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }//end of Unpause

    public void ReturnMenu()
    {
        Time.timeScale = 1f;
        //Goes to main menu
        SceneManager.LoadScene("MainMenu");
    }//end of ReturnMenu

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }//end of QuitGame
}
