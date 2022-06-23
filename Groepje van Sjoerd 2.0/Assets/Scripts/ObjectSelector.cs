using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public GameObject[] objects;
    public Transform spawnpoint;
    public Transform waitPos;
    public int counter;
    public bool canSpawn;
   
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            RandomObjectSpawner();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter++;
            if (counter == 1)
            {
                Instantiate(objects[0], spawnpoint.position,spawnpoint.rotation);
            }
            if (counter == 2)
            {
                Instantiate(objects[1], spawnpoint.position, transform.rotation);
            }
            if (counter == 3)
            {
                Instantiate(objects[2], spawnpoint.position, transform.rotation);
            }
            if (counter == 4)
            {
                Instantiate(objects[3], spawnpoint.position, transform.rotation);
            }
            if (counter == 5)
            {
                Instantiate(objects[4], spawnpoint.position, transform.rotation);
            }
            if (counter == 6)
            {
                Instantiate(objects[5], spawnpoint.position, transform.rotation);
                counter = 0;
            }
        }
    }

    public void RandomObjectSpawner()
    {
        if (canSpawn == false)
        {
            GameObject spawn = objects[Random.Range(0, objects.Length)];
            Instantiate(spawn, spawnpoint.position, Quaternion.identity, transform);
            canSpawn = true;
        }
    }
}
