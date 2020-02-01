using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public ObjectDifficulty difficulty;
    [SerializeField] private Transform childTransform;
    private void Update()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        
        transform.Rotate(x, -y, 0,Space.World);
    }
}
