using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        // Getting the saved time from the PlayerPrefs
        MinCount = PlayerPrefs.GetInt ("MinSave");
        SecCount = PlayerPrefs.GetInt ("SecSave");
        MilliCount = PlayerPrefs.GetFloat ("MilliSave");

        // Problem error
        // and displaying that time.
        MinDisplay.GetComponent<Text>().text = "" + MinCount + ":";
		SecDisplay.GetComponent<Text>().text = "" + SecCount + ".";
		MilliDisplay.GetComponent<Text>().text = "" + MilliCount;
    }

}
