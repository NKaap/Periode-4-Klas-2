using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public GameObject[] objects;
    public Transform spawnpoint;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {

    }

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
                Instantiate(objects[0], spawnpoint.position, Quaternion.identity, transform);
            }
            if (counter == 2)
            {
                Instantiate(objects[1], spawnpoint.position, Quaternion.identity, transform);
            }
            if (counter == 3)
            {
                Instantiate(objects[2], spawnpoint.position, Quaternion.identity, transform);
                counter = 0;
            }
        }
    }

    public void RandomObjectSpawner()
    {
        GameObject spawn = objects[Random.Range(0, objects.Length)];
        Instantiate(spawn, spawnpoint.position, Quaternion.identity, transform);
       
    }
}
