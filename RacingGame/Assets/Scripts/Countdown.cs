using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // Variables
    public GameObject CountDown;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public GameObject CarControl;
    public AudioSource LvlMusic;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (CountStart ());
                LvlMusic.Play ();
    }

    IEnumerator CountStart () {
        yield return new WaitForSeconds (0.5f);
        CountDown.GetComponent<Text> ().text = "3";

        // for now it wont work but after we place the sound we remove it from a comment
        // these will play a sound.
        GetReady.Play ();
        CountDown.SetActive (true);
        yield return new WaitForSeconds (1);
        CountDown.SetActive (false);
        CountDown.GetComponent<Text> ().text = "2";
        // for now it wont work but after we place the sound we remove it from a comment
        // these will play a sound.
        //GetReady.Play ();
        CountDown.SetActive (true);
        yield return new WaitForSeconds (1);
        CountDown.SetActive (false);
        CountDown.GetComponent<Text> ().text = "1";
        // for now it wont work but after we place the sound we remove it from a comment
        // these will play a sound.
        //GetReady.Play ();
        CountDown.SetActive (true);
        yield return new WaitForSeconds (1);
        CountDown.SetActive (false);
        // for now it wont work but after we place the sound we remove it from a comment
        // these will play a sound.
        GoAudio.Play ();
        LapTimer.SetActive (true);
        CarControl.SetActive (true);
        

    }

}
