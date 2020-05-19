using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public WheelCollider WheelFrontLeftCol; //the wheel coliders
    public WheelCollider WheelFrontRightCol;
    public WheelCollider WheelRearLeftCol;
    public WheelCollider WheelRearRightCol;


    public GameObject FrontLeftWheel; //the wheel gameObjects
    public GameObject FrontRightWheel;
    public GameObject RearLeftWheel;
    public GameObject RearRightWheel;
    
    public Vector3 centerOfMass;
    public float topSpeed = 250f; //top speed
    public float maxTorque = 200f; //maximum torque applied to wheels
    public float maxSteerAngle = 45f;
    public float currentSpeed;
    public float maxBrakeTorque = 2200f;

    private float Forward;
    private float Turn;
    private float Brake;

    private Rigidbody rb;
    
    public Text speedo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        rb.centerOfMass = centerOfMass;
    }

    // Update is called once per frame
    void FixedUpdate() //better optimised for physics than Update()
    {
        Forward = Input.GetAxis("Vertical");
        Turn = Input.GetAxis("Horizontal");
        Brake = Input.GetAxis("Jump");
        
        WheelFrontLeftCol.steerAngle =  maxSteerAngle * Turn;
        WheelFrontRightCol.steerAngle =  maxSteerAngle * Turn;

        currentSpeed = 2 * (22 / 7) * WheelRearLeftCol.radius * WheelRearLeftCol.rpm * 60 / 1000; //formula for calc speed in km/h
        currentSpeed = Mathf.Round(currentSpeed);
        speedo.text = currentSpeed + " KM/H";

        if(currentSpeed <= topSpeed){
            WheelRearLeftCol.motorTorque = maxTorque * Forward; //Rear Wheel Drive movement
            WheelRearRightCol.motorTorque = maxTorque * Forward;
            //top speed may not be fully accurate but will attempt to limit the car before set top speed value

            WheelRearLeftCol.brakeTorque = maxBrakeTorque * Brake;
            WheelRearRightCol.brakeTorque = maxBrakeTorque * Brake;
            WheelFrontLeftCol.brakeTorque = maxBrakeTorque * Brake;
            WheelFrontRightCol.brakeTorque = maxBrakeTorque * Brake;
        }
    }

    void Update() //called once per frame
    {
        Quaternion FLq; //rotation of wheel collider
        Vector3 FLv; //position of wheel collider
        WheelFrontLeftCol.GetWorldPose(out FLv, out FLq); //get wheel collider position and rotation
        FrontLeftWheel.transform.rotation = FLq;
        FrontLeftWheel.transform.position = FLv;
        
        Quaternion FRq; //rotation of wheel collider
        Vector3 FRv; //position of wheel collider
        WheelFrontRightCol.GetWorldPose(out FRv, out FRq); //get wheel collider position and rotation
        FrontRightWheel.transform.rotation = FRq;
        FrontRightWheel.transform.position = FRv;

        Quaternion RLq; //rotation of wheel collider
        Vector3 RLv; //position of wheel collider
        WheelRearLeftCol.GetWorldPose(out RLv, out RLq); //get wheel collider position and rotation
        RearLeftWheel.transform.rotation = RLq;
        RearLeftWheel.transform.position = RLv;

        Quaternion RRq; //rotation of wheel collider
        Vector3 RRv; //position of wheel collider
        WheelRearRightCol.GetWorldPose(out RRv, out RRq); //get wheel collider position and rotation
        RearRightWheel.transform.rotation = RRq;
        RearRightWheel.transform.position = RRv;

    }
}

