#region

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class ConveyerSpawnObject : MonoBehaviour
{
    private GameObject currentObject;
    [SerializeField] private List<GameObject> objectsToSpawn = new List<GameObject>();
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private TextMeshProUGUI nbSpawnLeftText;
    [SerializeField] private GameObject valideBoutton;
    private int nbSpawnLeft = 10;
    private bool canSpawnItem;

    public void AllowSpawnItem()
    {
        canSpawnItem = true;
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (canSpawnItem && currentObject == null )
        {
            if(nbSpawnLeft > 0)
            {
                currentObject = SpawnRandomObject();
                currentObject.GetComponent<RotateObject>().enabled = false;
            }
            else
            {
                valideBoutton.SetActive(true);
                if (Input.GetButton("A"))
                {
                    
                    SceneManager.LoadScene(0);
                }
            }
        }

        nbSpawnLeftText.text = "" + nbSpawnLeft;
    }

    private GameObject SpawnRandomObject()
    {
        nbSpawnLeft--;
        int randomIndex = Random.Range(0, objectsToSpawn.Count);
        return Instantiate(objectsToSpawn[randomIndex], spawnPoint.position, spawnPoint.rotation);
    }

    public void IncreaseNumberSpawn() {
        nbSpawnLeft++;
    }
}