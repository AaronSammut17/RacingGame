using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFinish : MonoBehaviour
{
    // Variables
    public GameObject CarControl;
    public GameObject AICarControl;
    public GameObject FinishCam;
    public GameObject MainCamera;
    public GameObject LevelMusic;
    public GameObject CompleteTrig;
    public GameObject LapTime;
    public GameObject WinMusic;
    public GameObject LoseMusic;
    public GameObject WinUI;
    public GameObject LoseUI;

    void OnTriggerEnter (Collider other) {

        
        CarControl.SetActive (false);
        AICarControl.SetActive (false);
        CarControl.GetComponent<CarController>().currentSpeed = 0.0f;
        AICarControl.GetComponent<NewController>().currentSpeed = 0.0f;
        CarControl.SetActive (true);
        AICarControl.SetActive (true);
        CompleteTrig.SetActive (false);
        FinishCam.SetActive (true);
        LevelMusic.SetActive (false);
        MainCamera.SetActive (false);
        LapTime.SetActive (false);
        if (other.CompareTag("Player")) {
            WinMusic.SetActive (true);
            WinUI.SetActive (true);
        }
        if (other.CompareTag("Opponent")) {
            LoseMusic.SetActive (true);
            LoseUI.SetActive (true);
        }
        
        
    }
}
