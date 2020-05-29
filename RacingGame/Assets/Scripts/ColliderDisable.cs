using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisable : MonoBehaviour
{
    void OnTriggerEnter(Collider obstacle){
        obstacle.GetComponent<Collider>().enabled = false;
    }
}
