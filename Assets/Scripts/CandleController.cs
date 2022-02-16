using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    public int candleOrderNumber;
    public BarrierController barrierToUnlock;
    public Sprite activeSprite;

    public GameObject interactText;
    public GameObject errorText;
    public GameObject interactGlow;

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
                    gameObject.GetComponent<SpriteRenderer>().sprite = activeSprite;
                    interactText.SetActive(false);
                    interactGlow.SetActive(false);
                    errorText.SetActive(false);
                    barrierToUnlock.checkForUnlock(candleOrderNumber);
                }
                else
                {
                    //If the candle previous to the last is activated, activate this current one
                    if (barrierToUnlock.allCandles[candleOrderNumber - 1].isActivated)
                    {
                        isActivated = true;
                        Debug.Log("Candle " + candleOrderNumber + " Successfully Activated!");
                        gameObject.GetComponent<SpriteRenderer>().sprite = activeSprite;
                        interactText.SetActive(false);
                        interactGlow.SetActive(false);
                        errorText.SetActive(false);
                        barrierToUnlock.checkForUnlock(candleOrderNumber);
                    }
                    else
                        StartCoroutine(FailMessage());
                }
            }
        }
    }

    IEnumerator FailMessage()
    {
        errorText.SetActive(true);

        yield return new WaitForSeconds(3);

        errorText.SetActive(false);
    }//end of FailMessage

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canActivate = true;
        if (!isActivated)
        {
            interactText.SetActive(true);
            interactGlow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canActivate = false;
        if (!isActivated)
        {
            interactText.SetActive(false);
            interactGlow.SetActive(false);
            errorText.SetActive(false);
        }
    }
}
