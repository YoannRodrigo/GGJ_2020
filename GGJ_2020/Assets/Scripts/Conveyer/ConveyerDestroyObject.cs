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
                ScoreSystem.Instance.Score = ScoreSystem.Instance.SetScore(other.gameObject, ScoreSystem.Instance.TimeLapsed,
                    out int freezeSecondsHolder, out bool timeIsFrozenHolder);
                ScoreSystem.Instance.freezeTime = freezeSecondsHolder;
                ScoreSystem.Instance.TimeIsFrozen = timeIsFrozenHolder;
                Debug.Log("gagne bonus"); //bonus fonction
            }

            Destroy(other.gameObject);
        }
    }
}