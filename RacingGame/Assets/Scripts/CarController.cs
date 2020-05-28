using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    public AudioSource CarAccelerate;
    public AudioSource CarDecelerate;
    public AudioSource CarIdle;

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

    public Transform wayPoints;
    public int currentWaypoint;
    public float distFromWaypoint;
    public List<Transform> waypoint;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        rb.centerOfMass = centerOfMass;

        waypoint = new List<Transform>();

        getWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate() //better optimised for physics than Update()
    {
        CarIdle.Play();
        
        Forward = Input.GetAxis("Vertical");
        Turn = Input.GetAxis("Horizontal");
        Brake = Input.GetAxis("Jump");

        if(Input.GetKeyDown("up") || Input.GetKeyDown("w")){
            CarDecelerate.Stop();
            CarAccelerate.Play();
        }

        if(Input.GetKeyUp("up") || Input.GetKeyUp("w")){
            CarAccelerate.Stop();
            CarDecelerate.Play();
        }      
        

        WheelFrontLeftCol.steerAngle =  maxSteerAngle * Turn;
        WheelFrontRightCol.steerAngle =  maxSteerAngle * Turn;

        currentSpeed = 2 * (22 / 7) * WheelRearLeftCol.radius * WheelRearLeftCol.rpm * 60 / 1000; //formula for calc speed in km/h
      //  rigidSpeed
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
        calcWaypoint();

        if(Input.GetKeyDown("r")){
            Respawn();  
        }

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

    void getWaypoint()
    {
        Transform[] childObjects = wayPoints.GetComponentsInChildren<Transform>();

        for (int i = 0; i < childObjects.Length; i++)
        {
            Transform temp = childObjects[i];
            if (temp.gameObject.GetInstanceID() != GetInstanceID())
                waypoint.Add(temp);
        }
    }

    void calcWaypoint()
    {
        Vector3 steerVector = transform.InverseTransformPoint(new Vector3(waypoint[currentWaypoint].position.x, transform.position.y, waypoint[currentWaypoint].position.z));
        
        if (steerVector.magnitude <= distFromWaypoint)
        {
            currentWaypoint++;
        }

        if (currentWaypoint >= waypoint.Count)
        {
            currentWaypoint = 0;
        }
    }
    public void Respawn()
    {
        currentSpeed = 0f;
        WheelRearLeftCol.motorTorque = 0;
        this.transform.position = new Vector3(waypoint[(currentWaypoint-1)].position.x, waypoint[(currentWaypoint-1)].position.y, waypoint[currentWaypoint-1].position.z);
        Quaternion respawnFacing = Quaternion.LookRotation(this.transform.position, transform.up);
        Debug.Log("Player Respawned");
    }
}

