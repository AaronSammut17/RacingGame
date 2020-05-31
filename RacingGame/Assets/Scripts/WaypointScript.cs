using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    //used to draw Raycasts for waypoint system & insert into array
    public Color rayColor = Color.white;
    List<Transform> waypoint;

    void OnDrawGizmos() {
        Gizmos.color = rayColor;
        Transform[] waypoint_objs = transform.GetComponentsInChildren<Transform>();
        waypoint = new List<Transform>();

        foreach(Transform waypoint_obj in waypoint_objs) //foreach
        {
            if (waypoint_obj != transform){
                waypoint.Add(waypoint_obj);
            }
        }
        
        for (int i = 0; i < waypoint.Count; i++){
            Vector3 pos = waypoint[i].position;
            if (i > 0) {
                Vector3 prev = waypoint[i - 1].position;
                Gizmos.DrawLine(prev, pos);
                Gizmos.DrawWireSphere(pos, 2f);
            }
        }
    }
}
