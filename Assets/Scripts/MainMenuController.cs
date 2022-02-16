using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject mainMenuUI, optionsUI, howToPlayUI;
    public Slider musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        //Set default music volume
        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            PlayerPrefs.SetFloat("MusicVol", 7f);
            PlayerPrefs.SetInt("FirstTime", 1);
        }

        //Set any existing PlayerPrefs
        musicSlider.value = PlayerPrefs.GetFloat("MusicVol") / 0.1f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }//end of StartGame

    public void OptionsMenu()
    {
        mainMenuUI.SetActive(false);
        optionsUI.SetActive(true);
    }//end of OptionsMenu

    public void HowToPlayScreen()
    {
        mainMenuUI.SetActive(false);
        howToPlayUI.SetActive(true);
    }//end of HowToPlayScreen

    public void BackToMain(int menu)
    {
        switch (menu)
        {
            //From options menu
            case 0:
                optionsUI.SetActive(false);
                mainMenuUI.SetActive(true);
                break;
            //From How To Play screen
            case 1:
                howToPlayUI.SetActive(false);
                mainMenuUI.SetActive(true);
                break;
        }

    }//end of BackToMain

    public void ChangeMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value * 0.1f);
    }//end of ChangeMusicVolume

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }//end of QuitGame
}
