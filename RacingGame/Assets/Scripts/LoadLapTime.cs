using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLapTime : MonoBehaviour
{
    // Variables
    public int MinCount;
    public int SecCount;
    public float MilliCount;
    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MilliDisplay;

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene ();
 
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
 
        if (sceneName == "Track1") 
        {
            // Getting the saved time from the PlayerPrefs
            MinCount = PlayerPrefs.GetInt ("MinSaveTrack1");
            SecCount = PlayerPrefs.GetInt ("SecSaveTrack1");
            MilliCount = PlayerPrefs.GetFloat ("MilliSaveTrack1");

            // Problem error
            // and displaying that time.
            MinDisplay.GetComponent<Text>().text = "" + MinCount + ":";
            SecDisplay.GetComponent<Text>().text = "" + SecCount + ".";
            MilliDisplay.GetComponent<Text>().text = "" + MilliCount;

        }
        else if (sceneName == "Track2")
        {
            // Getting the saved time from the PlayerPrefs
            MinCount = PlayerPrefs.GetInt ("MinSaveTrack2");
            SecCount = PlayerPrefs.GetInt ("SecSaveTrack2");
            MilliCount = PlayerPrefs.GetFloat ("MilliSaveTrack2");

            // Problem error
            // and displaying that time.
            MinDisplay.GetComponent<Text>().text = "" + MinCount + ":";
            SecDisplay.GetComponent<Text>().text = "" + SecCount + ".";
            MilliDisplay.GetComponent<Text>().text = "" + MilliCount;

        }
        else if (sceneName == "Track3")
        {
            // Getting the saved time from the PlayerPrefs
            MinCount = PlayerPrefs.GetInt ("MinSaveTrack3");
            SecCount = PlayerPrefs.GetInt ("SecSaveTrack3");
            MilliCount = PlayerPrefs.GetFloat ("MilliSaveTrack3");

            // Problem error
            // and displaying that time.
            MinDisplay.GetComponent<Text>().text = "" + MinCount + ":";
            SecDisplay.GetComponent<Text>().text = "" + SecCount + ".";
            MilliDisplay.GetComponent<Text>().text = "" + MilliCount;

        }
        else if (sceneName == "Track4")
        {
            // Getting the saved time from the PlayerPrefs
            MinCount = PlayerPrefs.GetInt ("MinSaveTrack4");
            SecCount = PlayerPrefs.GetInt ("SecSaveTrack4");
            MilliCount = PlayerPrefs.GetFloat ("MilliSaveTrack4");

            // Problem error
            // and displaying that time.
            MinDisplay.GetComponent<Text>().text = "" + MinCount + ":";
            SecDisplay.GetComponent<Text>().text = "" + SecCount + ".";
            MilliDisplay.GetComponent<Text>().text = "" + MilliCount;

        }
        
    }

}
