using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerData : MonoBehaviour
{
    public GameObject timerUI;
    public TextMeshProUGUI countDownText;
    public float startingTimeSeconds = 300.0f;
    public bool isTimed = false;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTimeSeconds;
        //Do not show timer unless timed
        if (!isTimed)
            timerUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if((int)currentTime % 60 <= 9)
            countDownText.text = "Time: " + (int)(currentTime / 60) + ":0" + (int)(currentTime % 60);
        else
            countDownText.text = "Time: " + (int)(currentTime / 60) + ":" + (int)(currentTime % 60);

        if (currentTime <= 0)
        {
            currentTime = 0;
            // Your Code Here
        }

        if(isTimed)
            currentTime -= Time.deltaTime;
    }
}
