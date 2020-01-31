using UnityEngine;

public class ConveyerDestroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectToRepair"))
        {
            Destroy(other.gameObject);
        }
    }
}
