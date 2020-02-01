using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : GenericSingleton<ScoreSystem>
{
    #region VARIABLES
    public Text TimeTextField;
    public Text ScoreTextField;

    private static int score = 0;
    private float timeSinceObjectInFront;
    private float timeLapsed = 0;
    
    [SerializeField] private ConveyerStopObject conveyerStopObject;
    #endregion

    #region TIMER
    private void Update() {
        int minutes = 0;
        int seconds = 0;

        if (conveyerStopObject.IsFocused) {
            timeSinceObjectInFront += Time.deltaTime;
            minutes = Mathf.FloorToInt(timeSinceObjectInFront / 60);
            seconds = Mathf.FloorToInt(timeSinceObjectInFront - minutes * 60);
            timeLapsed = seconds;
        } else {
            timeSinceObjectInFront = 0;
            minutes = 0;
            seconds = 0;
        }
        
        TimeTextField.text = minutes + "m : " + seconds + "s";
        ScoreTextField.text = "Score : " + score;
    }
    
    #endregion

    #region SCORE
    public int SetScore(GameObject currentObject, float currentTimeLapsed) {
        switch (currentObject.GetComponent<RotateObject>().difficulty) {
            case (ObjectDifficulty.easy):
                if (currentTimeLapsed <= 10) {
                    score += 100;
                } else if (currentTimeLapsed <= 12) {
                    score += 75;
                } else if (currentTimeLapsed <= 15) {
                    score += 50;
                } else {
                    score += 25;
                }
                return score;
            case (ObjectDifficulty.normal):
                if (currentTimeLapsed <= 15) {
                    score += 100;
                } else if (currentTimeLapsed <= 18) {
                    score += 75;
                } else if (currentTimeLapsed <= 22) {
                    score += 50;
                } else {
                    score += 25;
                }
                return score;
            case (ObjectDifficulty.hard):
                if (currentTimeLapsed <= 20) {
                    score += 100;
                } else if (currentTimeLapsed <= 22) {
                    score += 75;
                } else if (currentTimeLapsed <= 26) {
                    score += 50;
                } else {
                    score += 25;
                }
                return score;

            default: return 0;
        }
    }

    public float TimeLapsed {
        get { return timeLapsed; }
    }

    public int Score {
        get { return score; }
        set { if (value >= 0) { score = value; } }
    }
    #endregion
}
