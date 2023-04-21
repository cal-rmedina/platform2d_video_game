using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
  //Array for multiple points of the path between the waypoints
  [SerializeField] private GameObject[] waypoints;
  private int currentWaypointIndex = 0;

  [SerializeField] private float speed = 2f;

  private void Update()
  {
    //Distance between two vectors, current waypoint index and the platform
    if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .01f)
    {
      currentWaypointIndex++;

      //Condition if the platform reaches the end set currentWaypointindex to 0
      if(currentWaypointIndex >= waypoints.Length)
      {
        currentWaypointIndex = 0;
      }
    }

    //Using MoveTowards to move the platform and velocity comes to play using Time.deltaTime
    transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
  }
}
