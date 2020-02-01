using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public enum Inputs { SOUTH, EAST, WEST, NORTH, NONE};

    public Dictionary<GameObject, Inputs> objectsToRemoveDic;



    // Start is called before the first frame update
    void Start() {
        objectsToRemoveDic = new Dictionary<GameObject, Inputs>();
        GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag("ObjectToRemove");
        foreach (GameObject obj in objectsToRemove) {
            objectsToRemoveDic.Add(obj, Inputs.NONE);
            Debug.Log("key : " + obj.name + "; value : " + Inputs.NONE);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddInputInDic(GameObject key) {
        if (objectsToRemoveDic.ContainsValue(Inputs.SOUTH)) {
            if (objectsToRemoveDic.ContainsValue(Inputs.WEST)) {
                if (objectsToRemoveDic.ContainsValue(Inputs.NORTH)) {
                    if (!objectsToRemoveDic.ContainsValue(Inputs.EAST)) {
                        objectsToRemoveDic[key] = Inputs.EAST;
                    }
                }
                else {
                    objectsToRemoveDic[key] = Inputs.NORTH;
                }
            }
            else {
                objectsToRemoveDic[key] = Inputs.WEST;
            }
        }
        else {
            objectsToRemoveDic[key] = Inputs.SOUTH;
        }
    }

    public void RemoveInputInDic(GameObject key) {
        objectsToRemoveDic[key] = Inputs.NONE;
    }

    public void DeleteObjectInDic(GameObject key) {
        objectsToRemoveDic.Remove(key);
    }
}
