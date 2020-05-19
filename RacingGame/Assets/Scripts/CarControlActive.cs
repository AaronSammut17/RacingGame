using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlActive : MonoBehaviour
{
    public GameObject CarControl;
    public GameObject AICarControl;

    void Start () {
        CarControl.GetComponent<CarController>().enabled = true;
        AICarControl.GetComponent<NewController>().enabled = true;
    }
}
