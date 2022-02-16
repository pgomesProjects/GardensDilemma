using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : MonoBehaviour
{
    public GameObject eventVolume;
    [HideInInspector]
    public bool isEventReady;

    void Start()
    {
        eventVolume.SetActive(false);
        isEventReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If the event is ready, spawn the event volume
        if (isEventReady)
        {
            eventVolume.SetActive(true);
            Destroy(this);
        }
    }
}
