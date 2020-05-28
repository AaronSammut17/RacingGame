using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryPoints : MonoBehaviour
{
    public static int points;
    public GameObject UIpoints;
    public GameObject track2;
    public GameObject track3;
    public GameObject track4;

    // Update is called once per frame
    void Update()
    {
        UIpoints.GetComponent<Text>().text = "" + points;
        
        if (points >= 1){
            track2.GetComponent<Button>().interactable = true;
        }
        if (points >= 4){
            track4.GetComponent<Button>().interactable = true;
        }
        if (points >= 7){
            track3.GetComponent<Button>().interactable = true;
        }
        
    }
}
