using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliderPowerup : MonoBehaviour
{
    // Variables
    public float duration = 4f;

    public GameObject DisableColider;
    public AudioSource BoostSoundEffect;

    
    void OnTriggerEnter (Collider other){
        if (other.CompareTag("Player")){
            StartCoroutine( PickupPlayer(other) );  
        }
    }

    IEnumerator PickupPlayer(Collider player){

        BoostSoundEffect.Play();
        
        DisableColider.SetActive(true);
        
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        DisableColider.SetActive(false);

        yield return new WaitForSeconds(duration);
        
        GetComponent<Collider>().enabled = true;
        
    }
}
