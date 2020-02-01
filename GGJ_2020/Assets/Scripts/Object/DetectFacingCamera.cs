using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DetectFacingCamera : MonoBehaviour {
    private GameObject camera;
    [SerializeField]
    private int cameraLayer;
    private int layerMask;

    private bool isDetectingCamera;
    private bool hasSpawnParticule;

    [SerializeField]
    private GameObject particuleButtonIcon;
    [SerializeField]
    private GameObject particuleObjectIcon;

    [SerializeField]
    private GameObject objectToRemove;
    [SerializeField]
    private float distanceRemove = 1f;

    private Repair mainObject;

    public void SetGameObjects(GameObject particuleButtonIcon, GameObject objectToRemove)
    {
        this.particuleButtonIcon = particuleButtonIcon;
        this.objectToRemove = objectToRemove;
    }

    private void Start() {
        layerMask = 1 << cameraLayer;   // Bit shift the index of the layer to get a bit mask, This would cast rays only against colliders in layer cameraLayer.
        //for (int i = 0; i < transform.childCount; i++) {
        //    if (transform.GetChild(i).tag == "ObjectToRemove") {
        //        objectToRemove = transform.GetChild(i).gameObject;
        //    }
        //}
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        mainObject = transform.root.GetComponent<Repair>();
        if (mainObject) { Debug.Log(mainObject.name); }
        else { Debug.Log("mainObject not find"); }
    }

    private void Update() {
        if(particuleButtonIcon/* && particuleObjectIcon*/)
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

        if (isDetectingCamera) {
            ShowIcons();

        } else {
            HideIcons();
        }

        if (mainObject.objectsToRemoveDic.ContainsKey(objectToRemove)) {
            if (isDetectingCamera && mainObject.objectsToRemoveDic[objectToRemove] == Repair.Inputs.NONE) {
                mainObject.AddInputInDic(objectToRemove);
                
            } else if (!isDetectingCamera) {
                mainObject.RemoveInputInDic(objectToRemove);
            }
        }

        if (Input.GetButtonDown("Fire1")) {
            if (mainObject.objectsToRemoveDic.ContainsKey(objectToRemove)) {
                Debug.Log("gameobject : " + gameObject + "; value : " + mainObject.objectsToRemoveDic[objectToRemove]);
                if (isDetectingCamera && mainObject.objectsToRemoveDic[objectToRemove] == Repair.Inputs.SOUTH) {
                    //enlever objet
                    RemoveObject();
                }
            }
        }
        else if (Input.GetButtonDown("Fire3")) {
            if (mainObject.objectsToRemoveDic.ContainsKey(objectToRemove)) {
                if (isDetectingCamera && mainObject.objectsToRemoveDic[objectToRemove] == Repair.Inputs.WEST) {
                    //enlever objet
                    RemoveObject();
                }
            }
        }
        else if (Input.GetButtonDown("Jump")) {
            if (mainObject.objectsToRemoveDic.ContainsKey(objectToRemove)) {
                if (isDetectingCamera && mainObject.objectsToRemoveDic[objectToRemove] == Repair.Inputs.NORTH) {
                    //enlever objet
                    RemoveObject();
                }
            }
        }
        else if (Input.GetButtonDown("Fire2")) {
            if (mainObject.objectsToRemoveDic.ContainsKey(objectToRemove)) {
                if (isDetectingCamera && mainObject.objectsToRemoveDic[objectToRemove] == Repair.Inputs.EAST) {
                    //enlever objet
                    RemoveObject();
                }
            }
        }
    }

    private void RemoveObject() {
        Debug.Log("enlever objet");
        mainObject.DeleteObjectInDic(objectToRemove);
        objectToRemove.transform.DOLocalMoveZ(distanceRemove, 1f).OnComplete(() => objectToRemove.SetActive(false));
    }

    private void ShowIcons() {
        if(particuleButtonIcon)
            particuleButtonIcon.SetActive(true);  //Show button
        //particuleObjectIcon.SetActive(true);    //Show highlight
        //if (!hasSpawnParticule) {
        //    hasSpawnParticule = true;
        //    //dire a l'obj on face cam

        //}
        //Debug.Log("input associé : " + mainObject.objectsToRemoveDic[objectToRemove]);
    }

    private void HideIcons() {
        if(particuleButtonIcon)
                particuleButtonIcon.SetActive(false); //Hide Icon
        //particuleObjectIcon.SetActive(false);   //Hide highlight
        //if (hasSpawnParticule) {
        //    hasSpawnParticule = false;
        //    //dire a l'obj on face plus la cam

        //}
    }
}
