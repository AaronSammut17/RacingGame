﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    // Variables
    
    public float multiplier = 10000000f;
    public float duration = 4f;

    
    void OnTriggerEnter (Collider other){

        if (other.CompareTag("Player")){
            
            StartCoroutine( Pickup(other) );
            
        }
    }

    IEnumerator Pickup(Collider player){
        CarController boost = player.GetComponent<CarController>();
        boost.WheelRearLeftCol.motorTorque *= multiplier;
        boost.WheelRearRightCol.motorTorque *= multiplier;
        
        Debug.Log("power active");

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        boost.WheelRearLeftCol.motorTorque /= multiplier;
        boost.WheelRearRightCol.motorTorque /= multiplier;
        Debug.Log("power stops");
        Destroy(gameObject);
        
    }
    
}
