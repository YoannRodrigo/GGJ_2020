#region

using System.Collections.Generic;
using UnityEngine;

#endregion

public class Repair : MonoBehaviour
{
    public enum Inputs
    {
        SOUTH,
        EAST,
        WEST,
        NORTH,
        NONE
    }

    public bool isRepared;

    public Dictionary<GameObject, Inputs> objectsToRemoveDic;

    // Start is called before the first frame update
    private void Start()
    {
        CreateDicToRemove();
        CreateDicToAddd();
    }

    private void CreateDicToRemove()
    {
        objectsToRemoveDic = new Dictionary<GameObject, Inputs>();
        GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag("ObjectToRemove");
        foreach (GameObject obj in objectsToRemove)
        {
            objectsToRemoveDic.Add(obj, Inputs.NONE);
        }
    }

    private void CreateDicToAddd()
    {
        GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag("ObjectToAdd");
        foreach (GameObject obj in objectsToRemove)
        {
            objectsToRemoveDic.Add(obj, Inputs.NONE);
        }
    }

    public void AddInputInDic(GameObject key)
    {
        if (objectsToRemoveDic.ContainsValue(Inputs.SOUTH))
        {
            if (objectsToRemoveDic.ContainsValue(Inputs.WEST))
            {
                if (objectsToRemoveDic.ContainsValue(Inputs.NORTH))
                {
                    if (!objectsToRemoveDic.ContainsValue(Inputs.EAST))
                    {
                        objectsToRemoveDic[key] = Inputs.EAST;
                    }
                }
                else
                {
                    objectsToRemoveDic[key] = Inputs.NORTH;
                }
            }
            else
            {
                objectsToRemoveDic[key] = Inputs.WEST;
            }
        }
        else
        {
            objectsToRemoveDic[key] = Inputs.SOUTH;
        }
    }

    public void RemoveInputInDic(GameObject key)
    {
        objectsToRemoveDic[key] = Inputs.NONE;
    }

    public void DeleteObjectInDic(GameObject key)
    {
        objectsToRemoveDic.Remove(key);

        isRepared = objectsToRemoveDic.Count == 0;
    }
}