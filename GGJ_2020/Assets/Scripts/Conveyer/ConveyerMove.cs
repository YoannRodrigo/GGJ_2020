using System;
using UnityEngine;

public class ConveyerMove : MonoBehaviour
{
    private const float CONVEYER_SPEED = 0.1f;
    [HideInInspector] public bool canObjectBeMoved = true;
    private void OnCollisionStay(Collision other)
    {
        if ((other.transform.CompareTag("ObjectToRepair") || other.transform.CompareTag("ObjectToValidate")) && canObjectBeMoved)
        {
            other.transform.Translate(CONVEYER_SPEED,0,0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((other.transform.CompareTag("ObjectToRepair") || other.transform.CompareTag("ObjectToValidate")) && canObjectBeMoved)
        {
            other.transform.GetComponent<Rigidbody>().constraints += (int) RigidbodyConstraints.FreezePositionY;
        }
    }
}
