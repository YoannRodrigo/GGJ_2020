using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    [SerializeField]
    private Text scoreTextField;

    private void Awake() {
        scoreTextField.text = "Score : " + ScoreSystem.Instance.Score.ToString();
    }
}
