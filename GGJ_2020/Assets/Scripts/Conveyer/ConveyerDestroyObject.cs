#region

using UnityEngine;

#endregion

public class ConveyerDestroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectToRepair") || other.CompareTag("ObjectToValidate"))
        {
            if (other.GetComponent<Repair>().isRepared)
            {
                Debug.Log("gagne bonus"); //bonus fonction
            }

            Destroy(other.gameObject);
        }
    }
}