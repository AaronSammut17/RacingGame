using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{

    public Transform wayPoints;
    public Vector3 centerOfMass;

    public float maxSteerAngle = 45f;
    public float maxTorque = 50f;
    public float currentSpeed;
    public float topSpeed = 150f;
    public float decelerationSpeed = 10f;

    public WheelCollider WheelFrontLeftCol;
    public WheelCollider WheelFrontRightCol;
    public WheelCollider WheelRearLeftCol;
    public WheelCollider WheelRearRightCol;
    public GameObject FrontLeftWheel; //the wheel gameObjects
    public GameObject FrontRightWheel;
    public GameObject RearLeftWheel;
    public GameObject RearRightWheel;

    public int currentWaypoint;
    public float distFromWaypoint;

    public List<Transform> waypoint;
    private Rigidbody rb;
    
    void Start()
    {
        waypoint = new List<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
        getWaypoint();
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

      //  Debug.Log(pathList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        getSteer();
        Move();
        
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

    void getSteer()
    {
        Vector3 steerVector = transform.InverseTransformPoint(new Vector3(waypoint[currentWaypoint].position.x, transform.position.y, waypoint[currentWaypoint].position.z));
        float newSteer = maxSteerAngle * (steerVector.x / steerVector.magnitude);
        WheelFrontLeftCol.steerAngle = newSteer;
        WheelFrontRightCol.steerAngle = newSteer;

        if (steerVector.magnitude <= distFromWaypoint)
        {
            currentWaypoint++;
        }

        if (currentWaypoint >= waypoint.Count)
        {
            currentWaypoint = 0;
        }
    }

    
    void Move()
    {
        currentSpeed = 2 * (22 / 7) * WheelRearLeftCol.radius * WheelRearLeftCol.rpm * 60 / 1000;
        currentSpeed = Mathf.Round(currentSpeed);

        if (currentSpeed <= topSpeed)
        {
            WheelRearLeftCol.motorTorque = maxTorque;
            WheelRearRightCol.motorTorque = maxTorque;
            WheelRearLeftCol.brakeTorque = 0;
            WheelRearRightCol.brakeTorque = 0;
        }
        else
        {
            WheelRearLeftCol.motorTorque = 0;
            WheelRearRightCol.motorTorque = 0;
            WheelRearLeftCol.brakeTorque = decelerationSpeed;
            WheelRearRightCol.brakeTorque = decelerationSpeed;
        }
    }
    
}
