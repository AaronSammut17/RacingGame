using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{

    void OnTriggerEnter (Collider other){
            if (other.CompareTag("Player")){
                CarController playerRespawn = other.GetComponent<CarController>();
                playerRespawn.Respawn();
        } 
        
        if((other.CompareTag("Opponent"))){
                NewController opponentRespawn = other.GetComponent<NewController>();
                opponentRespawn.Respawn();
        }
    }
}
