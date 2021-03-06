using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerUntilMain : MonoBehaviour
{

    public static bool isWon = false;
    public float timeUntilMain = 5.0f;

    private float currentTime;

    // Update is called once per frame
    void Update()
    {
        if (isWon)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timeUntilMain)
            {
                FindObjectOfType<AudioManager>().Stop("LevelBGM");
                FindObjectOfType<AudioManager>().ChangePitch("LevelBGM", 1.0f);
                //Goes to main menu
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
