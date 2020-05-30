using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisable : MonoBehaviour
{
    public GameObject Stop;
    void OnTriggerEnter(Collider obstacle){
        if(obstacle.tag == "Obstacle"){
            obstacle.GetComponent<Collider>().enabled = false;
        }
        
        if(obstacle.tag == "Stop"){
            this.gameObject.SetActive(false);
            Stop.GetComponent<Collider>().enabled = true;
        }
    }
}
