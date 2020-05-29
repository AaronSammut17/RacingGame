using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{

    public AudioSource RespawnSoundEffect;

    void OnTriggerEnter (Collider other){
            if (other.CompareTag("Player")){
                RespawnSoundEffect.Play();
                CarController playerRespawn = other.GetComponent<CarController>();
                playerRespawn.Respawn();
        } 
        
        if((other.CompareTag("Opponent"))){
                NewController opponentRespawn = other.GetComponent<NewController>();
                opponentRespawn.Respawn();
        }
    }
}
