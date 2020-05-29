using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    // Variables
    
    public float multiplier = 10000000f;
    public float duration = 4f;

    public AudioSource BoostSoundEffect;

    
    void OnTriggerEnter (Collider other){
        if (other.CompareTag("Opponent")){
            StartCoroutine( PickupOpponent(other) );  
        }
        if (other.CompareTag("Player")){
            StartCoroutine( PickupPlayer(other) );  
        }
    }

    IEnumerator PickupPlayer(Collider player){

        BoostSoundEffect.Play();
        CarController boost = player.GetComponent<CarController>();
        boost.WheelRearLeftCol.motorTorque *= multiplier;
        boost.WheelRearRightCol.motorTorque *= multiplier;
        boost.currentSpeed += 20f;
        

        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        boost.WheelRearLeftCol.motorTorque /= multiplier;
        boost.WheelRearRightCol.motorTorque /= multiplier;
        boost.currentSpeed -= 20f;
        
        yield return new WaitForSeconds(duration);
        
        GetComponent<Collider>().enabled = true;
        
    }

    IEnumerator PickupOpponent(Collider opponent){

        NewController boost = opponent.GetComponent<NewController>();
        boost.WheelRearLeftCol.motorTorque *= multiplier;
        boost.WheelRearRightCol.motorTorque *= multiplier;
        boost.currentSpeed += 20f;
        

        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        boost.WheelRearLeftCol.motorTorque /= multiplier;
        boost.WheelRearRightCol.motorTorque /= multiplier;
        boost.currentSpeed -= 20f;
        
        yield return new WaitForSeconds(duration);
        
        GetComponent<Collider>().enabled = true;
        
    }
    
}
