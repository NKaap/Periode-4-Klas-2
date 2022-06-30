using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptButton : MonoBehaviour
{
    public List<GameObject> objectToSpawn;
    public GameObject spawnPos;

    public void SpawnObject(int objectNumber)
    {
        Instantiate(objectToSpawn[objectNumber], spawnPos.transform.position, Quaternion.identity);
    }
}
