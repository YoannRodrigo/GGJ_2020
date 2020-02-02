#region

using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

#endregion

public class DetectFacingCamera : MonoBehaviour
{
    private GameObject camera;

    [SerializeField] private int cameraLayer;

    private GameObject currentIconeButton;

    [SerializeField] private float distanceRemove = 1f;

    private GameCanvasManager gameManager;
    private bool gameObjectNeedTobeRemoved;
    private bool hasSpawnParticule;
    [SerializeField] private List<GameObject> iconesButton = new List<GameObject>();
    private bool isDetectingCamera;
    private int layerMask;

    private Repair mainObject;

    [SerializeField] private GameObject objectToRemove;

    [SerializeField] private Transform particuleButtonIcon;

    [SerializeField] private GameObject particuleObjectIcon;

    public void SetGameObjectsToRemove(Transform particuleButtonIcon, GameObject objectToRemove)
    {
        gameObjectNeedTobeRemoved = true;
        this.particuleButtonIcon = particuleButtonIcon;
        this.objectToRemove = objectToRemove;
    }

    public void SetGameObjectsToAdd(Transform particuleButtonIcon, GameObject objectToAdd)
    {
        gameObjectNeedTobeRemoved = false;
        this.particuleButtonIcon = particuleButtonIcon;
        objectToRemove = objectToAdd;
    }

    private void Start()
    {
        layerMask = 1 << cameraLayer; // Bit shift the index of the layer to get a bit mask, This would cast rays only against colliders in layer cameraLayer.
        //for (int i = 0; i < transform.childCount; i++) {
        //    if (transform.GetChild(i).tag == "ObjectToRemove") {
        //        objectToRemove = transform.GetChild(i).gameObject;
        //    }
        //}
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        gameManager = FindObjectOfType<GameCanvasManager>();
        mainObject = transform.root.GetComponent<Repair>();
    }

    private void Update()
    {
        if (particuleButtonIcon /* && particuleObjectIcon*/)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit,
                Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                    Color.yellow);
                isDetectingCamera = true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                isDetectingCamera = false;
            }
        }

        if (isDetectingCamera)
        {
            ShowIcons();
        }
        else
        {
            HideIcons();
        }

        if (mainObject.objectsToRemoveDic.ContainsKey(objectToRemove))
        {
            if (isDetectingCamera && mainObject.objectsToRemoveDic[objectToRemove] == Repair.Inputs.NONE)
            {
                mainObject.AddInputInDic(objectToRemove);
            }
            else if (!isDetectingCamera)
            {
                mainObject.RemoveInputInDic(objectToRemove);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (mainObject.objectsToRemoveDic.ContainsKey(objectToRemove))
            {
                if (isDetectingCamera && mainObject.objectsToRemoveDic[objectToRemove] == Repair.Inputs.SOUTH)
                {
                    //enlever objet
                    RemoveObject();
                }
            }
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            if (mainObject.objectsToRemoveDic.ContainsKey(objectToRemove))
            {
                if (isDetectingCamera && mainObject.objectsToRemoveDic[objectToRemove] == Repair.Inputs.WEST)
                {
                    //enlever objet
                    RemoveObject();
                }
            }
        }
        else if (Input.GetButtonDown("Jump"))
        {
            if (mainObject.objectsToRemoveDic.ContainsKey(objectToRemove))
            {
                if (isDetectingCamera && mainObject.objectsToRemoveDic[objectToRemove] == Repair.Inputs.NORTH)
                {
                    //enlever objet
                    RemoveObject();
                }
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (mainObject.objectsToRemoveDic.ContainsKey(objectToRemove))
            {
                if (isDetectingCamera && mainObject.objectsToRemoveDic[objectToRemove] == Repair.Inputs.EAST)
                {
                    //enlever objet
                    RemoveObject();
                }
            }
        }
    }

    private void RemoveObject()
    {
        if (objectToRemove.CompareTag("ObjectToRemove") && gameManager.IsLeftActive() &&
            gameManager.GetCurrentLeftTool().Contains(name))
        {
            FindObjectOfType<SoundManager>().PlayASoundOnRemove(name);
            mainObject.DeleteObjectInDic(objectToRemove);
            objectToRemove.transform.DOLocalMoveZ(distanceRemove, 1f).OnComplete(() =>
            {
                gameManager.currentNbHoleFix++;
                Destroy(gameObject);
            });
        }

        if (objectToRemove.CompareTag("ObjectToAdd") && gameManager.IsRightActive() &&
            gameManager.GetCurrentRightTool().Contains(name))
        {
            FindObjectOfType<SoundManager>().PlayASoundOnAdd(name);
            mainObject.DeleteObjectInDic(objectToRemove);
            GameObject newItem = GetComponent<AddObjectAndIcone>().SpawnItemToAdd();
            newItem.transform.DOMove(transform.position, 1f).OnComplete(() =>
            {
                gameManager.currentNbHoleFix++;
                Destroy(objectToRemove.gameObject);
                Destroy(currentIconeButton.gameObject);
                Destroy(this);
            });
        }
    }

    private void ShowIcons()
    {
        if (!currentIconeButton)
        {
            switch (mainObject.objectsToRemoveDic[objectToRemove])
            {
                case Repair.Inputs.SOUTH:
                    currentIconeButton = Instantiate(iconesButton[0],
                        particuleButtonIcon.position + 0.1f * particuleButtonIcon.forward,
                        particuleButtonIcon.rotation,
                        particuleButtonIcon);
                    break;
                case Repair.Inputs.WEST:
                    currentIconeButton = Instantiate(iconesButton[1],
                        particuleButtonIcon.position + 0.1f * particuleButtonIcon.forward,
                        particuleButtonIcon.rotation,
                        particuleButtonIcon);
                    break;
                case Repair.Inputs.NORTH:
                    currentIconeButton = Instantiate(iconesButton[2],
                        particuleButtonIcon.position + 0.1f * particuleButtonIcon.forward,
                        particuleButtonIcon.rotation,
                        particuleButtonIcon);
                    break;
                case Repair.Inputs.EAST:
                    currentIconeButton = Instantiate(iconesButton[3],
                        particuleButtonIcon.position + 0.1f * particuleButtonIcon.forward,
                        particuleButtonIcon.rotation,
                        particuleButtonIcon);
                    break;
                case Repair.Inputs.NONE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void HideIcons()
    {
        Destroy(currentIconeButton);
    }
}