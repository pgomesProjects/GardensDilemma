using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{

    public CandleController[] allCandles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkForUnlock(int latestCandle)
    {
        //If the latest candle is the last candle in the array, unlock the barrier
        if(latestCandle == allCandles.Length - 1)
        {
            //Deactivate self
            Destroy(gameObject);
        }
    }
}
