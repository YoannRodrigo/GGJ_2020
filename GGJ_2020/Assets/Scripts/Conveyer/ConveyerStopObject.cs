using System;
using DG.Tweening;
using UnityEngine;

public class ConveyerStopObject : MonoBehaviour
{
    private GameObject objectToRepair;
    [SerializeField] private ConveyerMove conveyerMove;
    [SerializeField] private Transform objectViewTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectToRepair"))
        {
            conveyerMove.canObjectBeMoved = false;
            objectToRepair = other.gameObject;
            objectToRepair.GetComponent<RotateObject>().enabled = true;
            Debug.DrawLine(objectViewTransform.position,objectToRepair.transform.position
                ,Color.blue,10);
        }
    }

    private void Update()
    {
        if (objectToRepair != null)
        {
            objectToRepair.transform.DOMove(objectViewTransform.position, 1f).SetEase(Ease.OutExpo);
        }
    }
}
