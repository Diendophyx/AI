using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform waypointParent;
    public NavMeshAgent agent;

    private Transform[] waypoints; //Creates collection of Transforms
    private int currentIndex = 0; //Keeps track of current element in array

    void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>(); //Getting the Transforms of all the children of waypointParent
        // waypointCount = waypoints.Length; //Sets waypointCount to the total amount of waypoints provided
    }

    void Update()
    {
        Transform point = waypoints[currentIndex + 1]; //Sets the target point to the current index + 1, skipping the parent
        float distance = Vector3.Distance(transform.position, point.position); //Gets the distance between the agent and its target

        if (distance < 1.0f)
        {
            currentIndex += 1; //Goes to next element in array 
            if (currentIndex >= waypoints.Length -1)
            {
                currentIndex = 0; //Resets the array to the first waypoint
            }
        }
        agent.SetDestination(point.position);
    }
}
