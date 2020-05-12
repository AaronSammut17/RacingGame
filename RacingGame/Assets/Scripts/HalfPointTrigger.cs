using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    // This script
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    void OnTriggerEnter(){
        // set the LapCompleteTrigger on/active
        LapCompleteTrig.SetActive(true);
        // set the HalfLapTrig off/not active
        HalfLapTrig.SetActive(false);
    }
}
