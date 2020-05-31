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
        if (other.CompareTag("Opponent1")){ //opponent pickup collision
            StartCoroutine( PickupOpponent(other) );  
        }
        if (other.CompareTag("Opponent2")){ //opponent pickup collision
            StartCoroutine( PickupOpponent(other) );  
        }
        if (other.CompareTag("Opponent3")){ //opponent pickup collision
            StartCoroutine( PickupOpponent(other) );  
        }
        if (other.CompareTag("Player")){ //player pickup collision
            StartCoroutine( PickupPlayer(other) );  
        }
    }

    IEnumerator PickupPlayer(Collider player){

        BoostSoundEffect.Play();
        CarController boost = player.GetComponent<CarController>(); //increase in torque and speed for player in tracks 1-3
        boost.WheelRearLeftCol.motorTorque *= multiplier;
        boost.WheelRearRightCol.motorTorque *= multiplier;
        boost.currentSpeed += 20f;

        CarControllerChase boostChase = player.GetComponent<CarControllerChase>(); //increase in torque and speed for player in track 4/chase mode
        boostChase.WheelRearLeftCol.motorTorque *= multiplier;
        boostChase.WheelRearRightCol.motorTorque *= multiplier;
        boostChase.currentSpeed += 20f;
        

        GetComponent<Collider>().enabled = false; //no-clip obstacles power for player in track 4/chase mode

        yield return new WaitForSeconds(duration);

        boost.WheelRearLeftCol.motorTorque /= multiplier; //torque and speed increase for player in tracks 1-3 wears off
        boost.WheelRearRightCol.motorTorque /= multiplier;
        boost.currentSpeed -= 20f;

        boostChase.WheelRearLeftCol.motorTorque /= multiplier; //torque and speed increase for player in track 4/chase mode wears off
        boostChase.WheelRearRightCol.motorTorque /= multiplier;
        boostChase.currentSpeed -= 20f;
        
        yield return new WaitForSeconds(duration);
        
        GetComponent<Collider>().enabled = true; //no-clip for player wears off
        
    }

    IEnumerator PickupOpponent(Collider opponent){

        NewController boost = opponent.GetComponent<NewController>(); //increase in torque and speed for opponent in tracks 1-3
        boost.WheelRearLeftCol.motorTorque *= multiplier;
        boost.WheelRearRightCol.motorTorque *= multiplier;
        boost.currentSpeed += 20f;

        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        boost.WheelRearLeftCol.motorTorque /= multiplier; //torque and speed increase for opponent in tracks 1-3 wears off
        boost.WheelRearRightCol.motorTorque /= multiplier;
        boost.currentSpeed -= 20f;
        
        yield return new WaitForSeconds(duration);
        
        GetComponent<Collider>().enabled = true;
        
        // no boost available for opponent in track 4/chase mode (too overpowered)
    }
    
}
