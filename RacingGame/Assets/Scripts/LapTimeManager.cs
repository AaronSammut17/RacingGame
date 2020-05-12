using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    // Variables
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;
    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

    public static float RawTime;

    // Update is called once per frame
    void Update()
    {
        // Its counting the millisecands of each frame
        MilliCount += Time.deltaTime * 10;

        RawTime += Time.deltaTime;

        // Converting the number to string to be able to deisplay it
        MilliDisplay = MilliCount.ToString("F0");
        // Adding the counter as a string to the UI 
        MilliBox.GetComponent<Text>().text = "" + MilliDisplay;

        // This if will set milliseconds the counter to 0
        if (MilliCount >= 10) {
            MilliCount = 0;
            // Adding a second when the milliseconds reaches 10
            SecondCount += 1;
        }

        // This if will display the seeconds counter
        // and it will remain the same format
        if (SecondCount <= 9){
            SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
        }
        else {
            SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
        }

        // This if will set the seconds counter to 0
        if (SecondCount >= 60){
            SecondCount = 0;
            // Adding a minute when the seconds reaches 60
            MinuteCount += 1;
        }

        // This if will display the minutes counter
        // and it will remain the same format
        if (MinuteCount <= 9){
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
        }
        else {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
        }
    }
}
