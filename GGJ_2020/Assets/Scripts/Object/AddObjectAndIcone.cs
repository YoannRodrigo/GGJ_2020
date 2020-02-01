using System.Collections.Generic;
using UnityEngine;

public class AddObjectAndIcone : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToRemove;
    [SerializeField] private List<GameObject> icones;
    private GameObject currentObjectToRemove;
    private GameObject currentIcone;

    private void Awake()
    {
        int randomIndex = Random.Range(0,objectsToRemove.Count);
        currentObjectToRemove =
            Instantiate(objectsToRemove[randomIndex], transform.position, Quaternion.identity, transform);
        randomIndex = Random.Range(0,icones.Count);
        currentIcone = Instantiate(icones[randomIndex], transform.position, Quaternion.identity, transform);
        GetComponent<DetectFacingCamera>().SetGameObjects(currentIcone, currentObjectToRemove);
    }
}
