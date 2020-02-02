#region

using UnityEngine;
using UnityEngine.UI;

#endregion

public class ShowScore : MonoBehaviour
{
    [SerializeField] private Text scoreTextField;

    private void Awake()
    {
        scoreTextField.text = "Score : " + ScoreSystem.Instance.Score;
    }
}