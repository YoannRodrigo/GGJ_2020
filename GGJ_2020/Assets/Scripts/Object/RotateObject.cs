using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Transform childTransform;
    private void Update()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        
        childTransform.Rotate(x, -y, 0,Space.World);
    }
}
