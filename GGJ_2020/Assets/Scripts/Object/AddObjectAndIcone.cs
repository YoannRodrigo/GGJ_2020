﻿#region

using System.Collections.Generic;
using UnityEngine;

#endregion

public class AddObjectAndIcone : MonoBehaviour
{
    private readonly List<string> objectToolNamesRemove = new List<string>(8)
        {"Antenna", "Flipper", "Nail", "Plug", "Screw", "Sparadras", "Button", "Banana"};

    private GameObject currentIcone;
    private GameObject currentObjectToRemove;
    [SerializeField] private List<GameObject> objectsToAdd;
    [SerializeField] private List<GameObject> objectsToRemove;
    private int randomIndex;

    private void Awake()
    {
        int randomChoice = Random.Range(0, 2);
        if (randomChoice == 0)
        {
            randomIndex = Random.Range(0, objectsToRemove.Count);
            currentObjectToRemove =
                Instantiate(objectsToRemove[randomIndex], transform.position, transform.rotation * Quaternion.Euler(90,0,0), transform);
            transform.name = objectToolNamesRemove[randomIndex];
            GetComponent<DetectFacingCamera>().SetGameObjectsToRemove(transform, currentObjectToRemove);
        }
        else
        {
            randomIndex = Random.Range(0, objectsToAdd.Count);
            currentObjectToRemove =
                Instantiate(objectsToAdd[randomIndex], transform.position, transform.rotation * Quaternion.Euler(90,0,0), transform);
            transform.name = objectToolNamesRemove[randomIndex];
            GetComponent<DetectFacingCamera>().SetGameObjectsToAdd(transform, currentObjectToRemove);
        }
    }

    public GameObject SpawnItemToAdd()
    {
        GameObject currentItemToAdd = Instantiate(objectsToRemove[randomIndex],
            transform.position + 0.8f * transform.forward, Quaternion.identity, transform);
        currentItemToAdd.tag = "ObjectToAdd";
        return currentItemToAdd;
    }
}