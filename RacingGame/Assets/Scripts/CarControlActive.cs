using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlActive : MonoBehaviour
{
    public GameObject CarControl;
    public GameObject AICarControl1;
    public GameObject AICarControl2;
    public GameObject AICarControl3;

    void Start () {
        CarControl.GetComponent<CarController>().enabled = true;
        AICarControl1.GetComponent<NewController>().enabled = true;
        AICarControl2.GetComponent<NewController>().enabled = true;
        AICarControl3.GetComponent<NewController>().enabled = true;
    }
}
