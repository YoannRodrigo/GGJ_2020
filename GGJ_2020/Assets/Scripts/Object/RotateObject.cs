using DG.Tweening;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public ObjectDifficulty difficulty;
    [SerializeField] private Transform childTransform;
    private void Update()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        bool validate = Input.GetAxis("Validate") > 0.0f;
        
        transform.Rotate(x, -y, 0,Space.World);

        if (validate)
        {
            Transform target = FindObjectOfType<ConveyerStopObject>().transform;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.DOMove(target.position, 1f).SetEase(Ease.OutExpo);
        }
    }
}
