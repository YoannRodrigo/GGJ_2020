#region

using UnityEngine;

#endregion

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonIcon;

    [SerializeField] private GameObject controllerIcon;

    private bool isControllerPlugged;

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
            buttonIcon.SetActive(true);
            controllerIcon.SetActive(false);
        }
        else
        {
            buttonIcon.SetActive(false);
            controllerIcon.SetActive(true);
        }
    }
}