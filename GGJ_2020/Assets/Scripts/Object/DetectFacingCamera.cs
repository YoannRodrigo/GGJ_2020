using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFacingCamera : MonoBehaviour {
    [SerializeField]
    private int cameraLayer;
    private int layerMask;

    private bool isDetectingCamera;
    private bool hasSpawnParticule;

    [SerializeField]
    private GameObject particuleButtonIcon;
    [SerializeField]
    private GameObject particuleObjectIcon;

    void Start() {
        layerMask = 1 << cameraLayer;   // Bit shift the index of the layer to get a bit mask, This would cast rays only against colliders in layer cameraLayer.
    }

    void Update() {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            isDetectingCamera = true;
        } else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            isDetectingCamera = false;
        }

        if (isDetectingCamera) {
            ShowIcons();

        } else {
            HideIcons();
        }
    }

    private void ShowIcons() {
        particuleButtonIcon.SetActive(true);  //Show button
        particuleObjectIcon.SetActive(true);    //Show highlight
    }

    private void HideIcons() {
        particuleButtonIcon.SetActive(false); //Hide Icon
        particuleObjectIcon.SetActive(false);   //Hide highlight
    }
}
