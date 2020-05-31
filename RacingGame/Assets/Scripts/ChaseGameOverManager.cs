using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseGameOverManager : MonoBehaviour
{

    public AudioSource LoseMusic;
    public AudioSource LvlMusic;
    public GameObject LoseUI;

    void OnTriggerEnter (Collider other){
            if (other.CompareTag("Player")){
                CarControllerChase wheelsPlayer = other.GetComponent<CarControllerChase>();
                wheelsPlayer.WheelRearLeftCol.motorTorque = 0;
                wheelsPlayer.WheelRearRightCol.motorTorque = 0;
                LoseMusic.Play();
                LvlMusic.Stop();
                LoseUI.SetActive (true);
        } 

                if((other.CompareTag("Opponent"))){
                NewControllerChase wheelsPolice = other.GetComponent<NewControllerChase>();
                wheelsPolice.WheelRearLeftCol.motorTorque = 0;
                wheelsPolice.WheelRearRightCol.motorTorque = 0;
                LoseMusic.Play();
                LvlMusic.Stop();
                LoseUI.SetActive (true);
        }
    }
}
