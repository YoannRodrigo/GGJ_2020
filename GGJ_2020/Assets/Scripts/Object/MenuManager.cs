#region

using System.Collections.Generic;
using UnityEngine;

#endregion

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonIcon;
    [SerializeField] private GameObject gameIcon;

    [SerializeField] private GameObject controllerIcon;
    [SerializeField] private List<GameObject> mainCanvas;

    private bool isControllerPlugged;
    private bool gameLaunched;

    private void Start()
    {
        Debug.Log(Input.GetJoystickNames()[0]);
    }

    // Update is called once per frame
    private void Update()
    {
        isControllerPlugged = Input.GetJoystickNames()[0].Length != 0;

        if (isControllerPlugged)
        {
            if (!gameLaunched)
            {
                buttonIcon.SetActive(true);
                controllerIcon.SetActive(false);
            }

            if (Input.GetButton("A"))
            {
                GetComponent<CanvasController>().enabled = true;
                foreach(GameObject canvasPart in mainCanvas)
                {
                    canvasPart.SetActive(true);
                }
                gameLaunched = true;
                buttonIcon.SetActive(false);
                gameIcon.SetActive(false);
                FindObjectOfType<ConveyerSpawnObject>().AllowSpawnItem();
            }
        }
        else
        {
            buttonIcon.SetActive(false);
            controllerIcon.SetActive(true);
        }

    }
}