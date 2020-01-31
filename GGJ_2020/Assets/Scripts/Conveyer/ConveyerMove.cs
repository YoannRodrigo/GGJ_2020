using UnityEngine;

public class ConveyerMove : MonoBehaviour
{
    private const float CONVEYER_SPEED = 0.02f;
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.CompareTag("ObjectToRepair"))
        {
            other.transform.Translate(CONVEYER_SPEED,0,0);
        }
    }
}
