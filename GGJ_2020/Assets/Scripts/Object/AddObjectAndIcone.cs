using System.Collections.Generic;
using UnityEngine;

public class AddObjectAndIcone : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToRemove;
    private GameObject currentObjectToRemove;
    private GameObject currentIcone;

    private void Awake()
    {
        int randomIndex = Random.Range(0,objectsToRemove.Count);
        currentObjectToRemove =
            Instantiate(objectsToRemove[randomIndex], transform.position, Quaternion.identity, transform);
        GetComponent<DetectFacingCamera>().SetGameObjects(transform, currentObjectToRemove);
    }
}
