using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [Header("Machine Settings")]
    public Transform[] waypoints;
    public int currentWaypoint;
    public bool machineIsOn;
    public AudioSource machineSound;

    [Header("Object Settings")]
    public GameObject machineObj;
    public float movementSpeed;

    [Header("Lift Settings")]
    public Transform[] liftWaypoints;
    public GameObject lift;

    public Transform[] liftWaypoints2;
    public GameObject lift2;

    public AudioSource liftSound;


    private void Update()
    {
        if(currentWaypoint == waypoints.Length - 1)
        {
            machineIsOn = false;
            machineSound.Stop(); liftSound.Stop();
            currentWaypoint = 0;
            lift2.transform.position = Vector3.MoveTowards(lift2.transform.position, liftWaypoints2[0].transform.position, movementSpeed * Time.deltaTime);
        }

        if (machineIsOn == true)
        {
            if (currentWaypoint == 2)
            {
                lift.transform.position = Vector3.MoveTowards(lift.transform.position, liftWaypoints[0].transform.position, movementSpeed * Time.deltaTime);
                if(liftSound.isPlaying == false)
                {
                    liftSound.Play();
                }
            }
            if(currentWaypoint != 2 && currentWaypoint != 3)
            {
                lift.transform.position = Vector3.MoveTowards(lift.transform.position, liftWaypoints[1].transform.position, movementSpeed * Time.deltaTime);
                liftSound.Stop();
            }
            if (currentWaypoint == 4)
            {
                lift2.transform.position = Vector3.MoveTowards(lift2.transform.position, liftWaypoints2[1].transform.position, movementSpeed * Time.deltaTime);
                if (liftSound.isPlaying == false)
                {
                    liftSound.Play();
                }
            }

            StartMachine();
        }

    }

    public void StartMachine()
    {
        Debug.Log("Started Machine");
        machineIsOn = true;
        if(machineSound.isPlaying == false)
        {
            machineSound.Play();
        }
        Transform waypoint = waypoints[currentWaypoint];
        if (Vector3.Distance(machineObj.transform.position, waypoint.position) < 0.01f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
        else
        {
            machineObj.transform.position = Vector3.MoveTowards(
                machineObj.transform.position,
                waypoint.position,
                movementSpeed * Time.deltaTime);

        }
    }
}
