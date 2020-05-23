using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICrowdController : MonoBehaviour
{
    public float sensorLength = 1f;
    public float speed = 10f;
    float directionValue = 1f;
    float turnValue = 0f;
    public float turnSpeed = 50f;
    Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = transform.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        int flag = 0;

        // Front sensor
        if (Physics.Raycast(transform.position, transform.forward, out hit, ((sensorLength + transform.localScale.z)))) {

            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider){
                return;
            }
            
            transform.Rotate(0f, Random.Range(-90f, 90f), 0f);

            flag++;
        }

        // Back sensor
        if (Physics.Raycast(transform.position, -transform.forward, out hit, ((sensorLength + transform.localScale.z)))) {
            
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider){
                return;
            }

            flag++;
        }
        // Right sensor
        if (Physics.Raycast(transform.position, transform.right, out hit, ((sensorLength + transform.localScale.x)))) {

            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider){
                return;
            }

            turnValue -= 1;
            flag++;
        }

        // Left sensor
        if (Physics.Raycast(transform.position, -transform.right, out hit, ((sensorLength + transform.localScale.x)))) {

            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider){
                return;
            }

            turnValue += 1;
            flag++;
        }

        if (flag == 0) {
            turnValue = 0;
        }
        transform.Rotate(Vector3.up *(turnSpeed * turnValue) * Time.deltaTime);
        transform.position += transform.forward * (speed * directionValue) *Time.deltaTime;
    }

    // Sensors
    void OnDrawGizmoz () {

        Gizmos.DrawRay(transform.position, transform.forward * (sensorLength + transform.localScale.z));
        Gizmos.DrawRay(transform.position, -transform.forward * (sensorLength + transform.localScale.z));
        Gizmos.DrawRay(transform.position, transform.right * (sensorLength + transform.localScale.x));
        Gizmos.DrawRay(transform.position, -transform.right * (sensorLength + transform.localScale.x));
    }
}
