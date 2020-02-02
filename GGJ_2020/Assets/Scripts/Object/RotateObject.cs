#region

using DG.Tweening;
using UnityEngine;

#endregion

public class RotateObject : MonoBehaviour
{
    private bool canBeMoved = true;
    [SerializeField] private Transform childTransform;
    public ObjectDifficulty difficulty;
    private bool isSoundPlayed;
    
    private void Update()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        bool validate = Input.GetAxis("Validate") > 0.0f;
        childTransform.Rotate(x, -y, 0, Space.World);

        if (validate)
        {
            if(!isSoundPlayed)
            {
                isSoundPlayed = true;
                AkSoundEngine.PostEvent("Validation", Camera.main.gameObject);
            }
            Transform target = FindObjectOfType<ConveyerStopObject>().transform;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            if (canBeMoved)
            {
                canBeMoved = false;
                transform.DOMove(target.position, 1f).SetEase(Ease.OutExpo);
            }

            if (target.GetComponent<ConveyerStopObject>().IsFocused)
            {
                
            }

            target.GetComponent<ConveyerStopObject>().IsFocused = false;
        }
    }
}