using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }//end of StartGame

    public void OptionsMenu()
    {

    }//end of OptionsMenu

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }//end of QuitGame
}
