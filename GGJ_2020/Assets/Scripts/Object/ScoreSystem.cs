using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text ScoreTextField;

    private int seconds = 0;
    private int minutes = 0;

    private void Awake() {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer() {
        while (true) {
            yield return new WaitForSeconds(1);
            seconds++;

            if (seconds == 60) {
                minutes++;
                seconds = 0;
            }

            ScoreTextField.text = minutes + "m : " + seconds + "s";
        }
    }
}
