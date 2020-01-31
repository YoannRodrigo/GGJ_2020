using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerSpawnObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToSpawn = new List<GameObject>();
    [SerializeField] private Transform spawnPoint;

    private GameObject currentObject;

    // Update is called once per frame
    private void Update()
    {
        if (currentObject == null)
        {
            currentObject = SpawnRandomObject();
        }
    }

    private GameObject SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Count);
        return Instantiate(objectsToSpawn[randomIndex], spawnPoint.position, spawnPoint.rotation);
    }
}
