using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseGameOverManager : MonoBehaviour
{

    public AudioSource LoseMusic;
    public GameObject LoseUI;

    void OnTriggerEnter (Collider other){
            if (other.CompareTag("Player")){
                LoseMusic.Play();
                LoseUI.SetActive (true);
        } 

                if((other.CompareTag("Opponent"))){
                LoseMusic.Play();
                LoseUI.SetActive (true);
        }
    }
}
