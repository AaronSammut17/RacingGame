using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    public GameObject PlayerCar;
    public float CarX;
    public float CarY;
    public float CarZ;
    
    //retains steady but fluid driving camera angle
    void Update(){
        CarX = PlayerCar.transform.eulerAngles.x;
        CarY = PlayerCar.transform.eulerAngles.y;
        CarZ = PlayerCar.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(CarX*-1, CarY, CarZ*-1);
    }
}
