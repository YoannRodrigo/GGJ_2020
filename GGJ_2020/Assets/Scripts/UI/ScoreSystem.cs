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
    public int freezeTime = 0;
    [SerializeField]
    private bool timeIsFrozen;

    private bool isEqualToFreezeTime;
    private float temp = 0;
    private int waitTime = 0;

    [SerializeField] private ConveyerStopObject conveyerStopObject;
    #endregion

    #region TIMER
    private void Update() {
        int minutes = 0;
        int seconds = 0;

        if (conveyerStopObject.IsFocused) {
            if (TimeIsFrozen) {
                
                if (!isEqualToFreezeTime) {
                    temp += Time.deltaTime;
                    waitTime = Mathf.FloorToInt(temp);

                    if (waitTime >= freezeTime) {
                        isEqualToFreezeTime = true;
                    }
                } else {
                    TimeIsFrozen = false;
                }

            } else {

                timeSinceObjectInFront += Time.deltaTime;
                minutes = Mathf.FloorToInt(timeSinceObjectInFront / 60);
                seconds = Mathf.FloorToInt(timeSinceObjectInFront - minutes * 60);
                timeLapsed = seconds;
                
            }
        } else {
            timeSinceObjectInFront = 0;
            minutes = 0;
            seconds = 0;
            waitTime = 0;
            temp = 0;
            isEqualToFreezeTime = false;
        }
        
        TimeTextField.text = minutes + "m : " + seconds + "s";
        ScoreTextField.text = "Score : " + score;
    }
    
    #endregion

    #region SCORE
    public int SetScore(GameObject currentObject, float currentTimeLapsed, out int freezeSeconds, out bool secondsFrozen) {
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
                    freezeSeconds = 3;
                    secondsFrozen = true;
                    return score;
                }
                freezeSeconds = 0;
                secondsFrozen = false;
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
                    freezeSeconds = 5;
                    secondsFrozen = true;
                    return score;
                }
                freezeSeconds = 0;
                secondsFrozen = false;
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
                    freezeSeconds = 7;
                    secondsFrozen = true;
                    return score;
                }
                freezeSeconds = 0;
                secondsFrozen = false;
                return score;

            default:
                freezeSeconds = 0;
                secondsFrozen = false;
                return 0;
        }
    }

    public float TimeLapsed {
        get { return timeLapsed; }
    }

    public int Score {
        get { return score; }
        set { if (value >= 0) { score = value; } }
    }

    public bool TimeIsFrozen {
        get { return timeIsFrozen; }
        set { timeIsFrozen = value; }
    }
    #endregion
}
