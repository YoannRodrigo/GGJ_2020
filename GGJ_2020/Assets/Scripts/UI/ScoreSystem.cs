using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    #region VARIABLES
    public Text ScoreTextField;
    
    private int score = 0;
    private float timeSinceObjectInFront;
    #endregion

    #region TIMER

    private void Update() {
        timeSinceObjectInFront += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeSinceObjectInFront / 60);
        int seconds = Mathf.FloorToInt(timeSinceObjectInFront - minutes * 60);
        ScoreTextField.text = minutes + "m : " + seconds + "s";

    }

    public void StartTimer() {
        timeSinceObjectInFront = 0;
    }
    #endregion

    #region SCORE
    public void SetScore(GameObject currentObject) {
        switch (currentObject.GetComponent<RotateObject>().difficulty) {
            case (ObjectDifficulty.easy):

                break;
            case (ObjectDifficulty.normal):
                break;
            case (ObjectDifficulty.hard):
                break;

            default: break;
        }
    }
    #endregion
}
