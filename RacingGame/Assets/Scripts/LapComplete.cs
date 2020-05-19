using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    // Variables
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;

    public GameObject LapTimeBox;

    public GameObject LapCounter;
    public int LapsDone = 1;
    public int AILapsDone = 1;

    public float RawTime;

    public GameObject RaceFinish;
    


    void OnTriggerEnter (Collider other) {

        // if player makes a lap
        if (other.CompareTag("Player")) {
            // This will add one when the player passes the finishline
            LapsDone += 1;

            if (LapsDone == 3){
                
                RaceFinish.SetActive (true);
            }

            // Problem error
            RawTime = PlayerPrefs.GetFloat ("RawTime");
            if (LapTimeManager.RawTime <= RawTime) {
                // These lines of code will grab the time from the script LapTimeManager
                // And it will display them in the best lap time after the player completes a lap.
                if (LapTimeManager.SecondCount <= 9) {
                    SecondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
                }
                else {
                    SecondDisplay.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
                }

                if (LapTimeManager.MinuteCount <= 9) {
                    MinuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ":";
                }
                else {
                    MinuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ":";
                }

                MilliDisplay.GetComponent<Text>().text = "" + LapTimeManager.MilliCount;
                
                // This Code is here to save the lap time and keeps these numbers
                // even after you close the game.
                PlayerPrefs.SetInt ("MinSave", LapTimeManager.MinuteCount);
                PlayerPrefs.SetInt ("SecSave", LapTimeManager.SecondCount);
                PlayerPrefs.SetFloat ("MilliSave", LapTimeManager.MilliCount);
            }
            
            // This Code is here to save the lap time and keeps these numbers
            // even after you close the game.
            PlayerPrefs.SetFloat ("RawTime", LapTimeManager.RawTime);

            // This code is setting the timer from the script LapTimeManager to 0.
            LapTimeManager.MinuteCount = 0;
            LapTimeManager.SecondCount = 0;
            LapTimeManager.MilliCount = 0;
            LapTimeManager.RawTime = 0;

            // It will show how many laps the player has done.
            LapCounter.GetComponent<Text>().text = "" + LapsDone;
            
            // This code will switch the triggers
            HalfLapTrig.SetActive (true);
            LapCompleteTrig.SetActive (false);
        }

        // if AI makes a lap
        if (other.CompareTag("Opponent")) {
           AILapsDone += 1;   
           if (AILapsDone == 3){
                
                RaceFinish.SetActive (true);
                
            }

        }
    }
}
