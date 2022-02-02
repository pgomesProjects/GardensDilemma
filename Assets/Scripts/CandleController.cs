using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    public int candleOrderNumber;
    public BarrierController barrierToUnlock;
    private bool canActivate;
    private bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        canActivate = false;
        isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If the candle is not activated and can activate it, check to see if the player is trying to activate it
        if (!isActivated && canActivate)
        {
            //If interacting with candle
            if (Input.GetAxis("Interact") > 0.1f)
            {
                //If first, simply activate it
                if(candleOrderNumber == 0)
                {
                    Debug.Log("Candle " + candleOrderNumber + " Successfully Activated!");
                    isActivated = true;
                    barrierToUnlock.checkForUnlock(candleOrderNumber);
                }
                else
                {
                    //If the candle previous to the last is activated, activate this current one
                    if(barrierToUnlock.allCandles[candleOrderNumber - 1].isActivated)
                    {
                        isActivated = true;
                        Debug.Log("Candle " + candleOrderNumber + " Successfully Activated!");
                        barrierToUnlock.checkForUnlock(candleOrderNumber);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canActivate = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canActivate = false;
    }
}
