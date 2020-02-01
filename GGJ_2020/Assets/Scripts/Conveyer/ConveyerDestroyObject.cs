using UnityEngine;

public class ConveyerDestroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectToRepair") || other.CompareTag("ObjectToValidate"))
        {
            Destroy(other.gameObject);
        }
    }
}
