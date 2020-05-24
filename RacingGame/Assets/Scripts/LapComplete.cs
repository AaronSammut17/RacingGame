using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public int LapsDone = 0;
    public int AILapsDone = 0;

    public float RawTime;

    public GameObject RaceFinish;
    


    void OnTriggerEnter (Collider other) {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene ();
 
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
 
        if (sceneName == "Track1") 
        {
            Debug.Log("track1");
            // if player makes a lap
            if (other.CompareTag("Player")) {
                // This will add one when the player passes the finishline
                LapsDone += 1;

                if (LapsDone == 3){
                    
                    RaceFinish.SetActive (true);
                    LapsDone = 0;
                }
                
                // Problem error
                RawTime = PlayerPrefs.GetFloat ("RawTimeTrack1");
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
                    PlayerPrefs.SetInt ("MinSaveTrack1", LapTimeManager.MinuteCount);
                    PlayerPrefs.SetInt ("SecSaveTrack1", LapTimeManager.SecondCount);
                    PlayerPrefs.SetFloat ("MilliSaveTrack1", LapTimeManager.MilliCount);
                }
                
                // This Code is here to save the lap time and keeps these numbers
                // even after you close the game.
                PlayerPrefs.SetFloat ("RawTimeTrack1", LapTimeManager.RawTime);

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
                    LapsDone = 0;
                }
            }  
        }

        if (sceneName == "Track2") 
        {
            // if player makes a lap
            if (other.CompareTag("Player")) {
                // This will add one when the player passes the finishline
                LapsDone += 1;

                if (LapsDone == 3){
                    RaceFinish.SetActive (true);
                    LapsDone = 0;
                }
                
                // Problem error
                RawTime = PlayerPrefs.GetFloat ("RawTimeTrack2");
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
                    PlayerPrefs.SetInt ("MinSaveTrack2", LapTimeManager.MinuteCount);
                    PlayerPrefs.SetInt ("SecSaveTrack2", LapTimeManager.SecondCount);
                    PlayerPrefs.SetFloat ("MilliSaveTrack2", LapTimeManager.MilliCount);
                }
                
                // This Code is here to save the lap time and keeps these numbers
                // even after you close the game.
                PlayerPrefs.SetFloat ("RawTimeTrack2", LapTimeManager.RawTime);

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
                    LapsDone = 0;
                }

            }  
        }

        if (sceneName == "Track3") {
            // if player makes a lap
            if (other.CompareTag("Player")) {
                // This will add one when the player passes the finishline
                LapsDone += 1;

                if (LapsDone == 2){
                    RaceFinish.SetActive (true);
                    LapsDone = 0;
                }
                
                // Problem error
                RawTime = PlayerPrefs.GetFloat ("RawTimeTrack3");
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
                    PlayerPrefs.SetInt ("MinSaveTrack3", LapTimeManager.MinuteCount);
                    PlayerPrefs.SetInt ("SecSaveTrack3", LapTimeManager.SecondCount);
                    PlayerPrefs.SetFloat ("MilliSaveTrack3", LapTimeManager.MilliCount);
                }
                
                // This Code is here to save the lap time and keeps these numbers
                // even after you close the game.
                PlayerPrefs.SetFloat ("RawTimeTrack3", LapTimeManager.RawTime);

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
                    LapsDone = 0;
                
                }
            }  
        }
    }
}
