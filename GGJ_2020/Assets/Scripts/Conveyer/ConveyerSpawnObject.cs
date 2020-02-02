#region

using System.Collections.Generic;
using UnityEngine;

#endregion

public class ConveyerSpawnObject : MonoBehaviour
{
    private GameObject currentObject;
    [SerializeField] private List<GameObject> objectsToSpawn = new List<GameObject>();
    [SerializeField] private Transform spawnPoint;

    // Update is called once per frame
    private void Update()
    {
        if (currentObject == null)
        {
            currentObject = SpawnRandomObject();
            currentObject.GetComponent<RotateObject>().enabled = false;
        }
    }

    private GameObject SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Count);
        return Instantiate(objectsToSpawn[randomIndex], spawnPoint.position, spawnPoint.rotation);
    }
}