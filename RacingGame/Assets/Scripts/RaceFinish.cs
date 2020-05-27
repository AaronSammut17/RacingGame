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
    public AudioSource WinMusic;
    public AudioSource LoseMusic;
    public GameObject WinUI;
    public GameObject LoseUI;

    void OnTriggerEnter (Collider other) {
        this.GetComponent<BoxCollider>().enabled = false;
        
        CompleteTrig.SetActive (false);
        FinishCam.SetActive (true);
        LevelMusic.SetActive (false);
        MainCamera.SetActive (false);
        LapTime.SetActive (false);
        if (other.CompareTag("Player")) {
            WinMusic.Play();
            WinUI.SetActive (true);
            
        }
        if (other.CompareTag("Opponent")) {
            LoseMusic.Play();
            LoseUI.SetActive (true);
        }
        
        
    }
}
