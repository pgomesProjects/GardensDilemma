using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{

    public CandleController[] allCandles;

    [HideInInspector]
    public bool isDeactivated;
    private float despawnY = 25f;
    private float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        isDeactivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeactivated)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (transform.position.y >= despawnY)
                Destroy(gameObject);
        }
    }

    public void checkForUnlock(int latestCandle)
    {
        //If the latest candle is the last candle in the array, unlock the barrier
        if(latestCandle == allCandles.Length - 1)
        {
            isDeactivated = true;

            if(GetComponent<SpawnEvent>() != null)
                GetComponent<SpawnEvent>().isEventReady = true;
        }
    }

}
