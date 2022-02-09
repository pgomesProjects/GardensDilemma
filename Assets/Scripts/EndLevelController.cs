using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelController : MonoBehaviour
{

    public GameObject victoryUI;
    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        victoryUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timer.GetComponent<TimerData>().isTimed = false;
            victoryUI.SetActive(true);
            LevelManager.isGameActive = false;
            TimerUntilMain.isWon = true;
            Destroy(gameObject);
        }
    }
}
