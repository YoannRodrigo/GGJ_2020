using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Animator fadeAnimator;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            StartCoroutine("SwitchScene");
        }
    }

    IEnumerator SwitchScene() {
        fadeAnimator.SetTrigger("triggerFade");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
