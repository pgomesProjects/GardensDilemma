using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEventController : MonoBehaviour
{
    public GameObject bossSprite;
    public GameObject timer;
    public float moveTime;
    public float yPos;

    public Vector2 startPos;
    public Vector2 endPos;

    private bool bossActive = false;
    private float timeStartedMove;

    void Update()
    {
        if (bossActive)
        {
            bossSprite.transform.localPosition = UseLerp(startPos, endPos, timeStartedMove, moveTime);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!bossActive)
        {
            bossActive = true;
            timeStartedMove = Time.time;

            FindObjectOfType<AudioManager>().ChangePitch("LevelBGM", 3.5f);

            //Activate timer
            timer.SetActive(true);
            timer.GetComponent<TimerData>().isTimed = true;
        }

    }//end of OnTriggerEnter2D
    public Vector3 UseLerp(Vector3 start, Vector3 end, float timeStarted, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedMove;

        float percentage = timeSinceStarted / lerpTime;
        start.z = 1;
        end.z = 1;
        return Vector3.Lerp(start, end, percentage);

    }//end of UseLerp
}
