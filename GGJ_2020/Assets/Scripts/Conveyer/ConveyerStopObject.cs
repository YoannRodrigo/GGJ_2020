#region

using System.Collections;
using DG.Tweening;
using UnityEngine;

#endregion

public class ConveyerStopObject : MonoBehaviour
{
    private bool canObjectBeMoved = true;
    [SerializeField] private ConveyerMove conveyerMove;
    private bool isFocused;
    private GameObject objectToRepair;
    [SerializeField] private Transform objectViewTransform;

    public bool IsFocused
    {
        get => isFocused;

        set => isFocused = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectToRepair"))
        {
            conveyerMove.canObjectBeMoved = false;
            objectToRepair = other.gameObject;
            objectToRepair.GetComponent<RotateObject>().enabled = true;
            objectToRepair.GetComponent<Rigidbody>().useGravity = false;
            objectToRepair.GetComponent<Rigidbody>().isKinematic = true;
            Debug.DrawLine(objectViewTransform.position, objectToRepair.transform.position
                , Color.blue, 10);

            isFocused = true;
        }
    }

    private void Update()
    {
        if (objectToRepair != null)
        {
            if (canObjectBeMoved)
            {
                canObjectBeMoved = false;
                objectToRepair.transform.DOMove(objectViewTransform.position, 1f).SetEase(Ease.OutExpo);
            }

            objectToRepair.tag = "ObjectToValidate";
            StartCoroutine(WaitForReset());
        }
    }

    private IEnumerator WaitForReset()
    {
        yield return new WaitForSeconds(1f);
        conveyerMove.canObjectBeMoved = true;
        objectToRepair = null;
        canObjectBeMoved = true;
    }
}