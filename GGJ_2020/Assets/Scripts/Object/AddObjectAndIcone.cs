using System.Collections.Generic;
using UnityEngine;

public class AddObjectAndIcone : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToRemove;
    [SerializeField] private List<GameObject> objectsToAdd;
    private GameObject currentObjectToRemove;
    private GameObject currentIcone;

    private void Awake()
    {
        int randomChoice = Random.Range(0, 2);
        if (randomChoice == 0)
        {
            int randomIndex = Random.Range(0, objectsToRemove.Count);
            currentObjectToRemove =
                Instantiate(objectsToRemove[randomIndex], transform.position, Quaternion.identity, transform);
            GetComponent<DetectFacingCamera>().SetGameObjectsToRemove(transform, currentObjectToRemove);
        }
        else
        {
            int randomIndex = Random.Range(0, objectsToAdd.Count);
            currentObjectToRemove =
                Instantiate(objectsToAdd[randomIndex], transform.position, Quaternion.identity, transform);
            GetComponent<DetectFacingCamera>().SetGameObjectsToAdd(transform, currentObjectToRemove);
        }
    }
}
