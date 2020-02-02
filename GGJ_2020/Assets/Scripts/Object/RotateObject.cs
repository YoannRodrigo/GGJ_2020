#region

using DG.Tweening;
using UnityEngine;

#endregion

public class RotateObject : MonoBehaviour
{
    private bool canBeMoved = true;
    [SerializeField] private Transform childTransform;
    public ObjectDifficulty difficulty;

    private void Update()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        bool validate = Input.GetAxis("Validate") > 0.0f;

        childTransform.Rotate(x, -y, 0, Space.World);

        if (validate)
        {
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
                ScoreSystem.Instance.Score = ScoreSystem.Instance.SetScore(gameObject, ScoreSystem.Instance.TimeLapsed,
                    out int freezeSecondsHolder, out bool timeIsFrozenHolder);
                ScoreSystem.Instance.freezeTime = freezeSecondsHolder;
                ScoreSystem.Instance.TimeIsFrozen = timeIsFrozenHolder;
            }

            target.GetComponent<ConveyerStopObject>().IsFocused = false;
        }
    }
}