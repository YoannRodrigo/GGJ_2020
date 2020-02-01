using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private bool isControllerPlugged;
    [SerializeField]
    private GameObject buttonIcon;
    [SerializeField]
    private GameObject controllerIcon;

    private void Start() {
        Debug.Log(Input.GetJoystickNames()[0]);
    }

    // Update is called once per frame
    void Update()
    {
        isControllerPlugged = Input.GetJoystickNames()[0].Length != 0;

        if (isControllerPlugged) {
            buttonIcon.SetActive(true);
            controllerIcon.SetActive(false);
        }
        else {
            buttonIcon.SetActive(false);
            controllerIcon.SetActive(true);
        }
    }
}
