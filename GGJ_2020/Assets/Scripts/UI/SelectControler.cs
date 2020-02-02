#region

using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

#endregion

public class SelectControler : MonoBehaviour
{
    public bool canbeMoved;
    private int currentIndex;
    private string currentTool;
    public List<Transform> framesPosition = new List<Transform>();
    private bool isPositionReset = true;

    private readonly List<string> objectToolNamesRemove = new List<string>(9)
        {"Plug", "Nail", "Button", "Stain", "Flipper", "Antenna", "Screw", "Banana", "Sparadras"};

    public string GetCurrentTool()
    {
        return currentTool;
    }

    private void Start()
    {
        transform.DOScale(1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        float x = Input.GetAxis("VerticalSelect");
        if (x > 0.5f)
        {
            SelectUp();
        }
        else if (x < -0.5f)
        {
            SelectDown();
        }
        else
        {
            isPositionReset = true;
        }

        transform.position = framesPosition[currentIndex].position;
        currentTool = objectToolNamesRemove[currentIndex];
    }

    private void SelectUp()
    {
        if (canbeMoved && isPositionReset)
        {
            isPositionReset = false;
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = framesPosition.Count - 1;
            }
            AkSoundEngine.PostEvent("Fleches_directionnelles", Camera.main.gameObject);
        }
    }

    private void SelectDown()
    {
        if (canbeMoved && isPositionReset)
        {
            isPositionReset = false;
            currentIndex++;
            if (currentIndex >= framesPosition.Count)
            {
                currentIndex = 0;
            }
            AkSoundEngine.PostEvent("Fleches_directionnelles", Camera.main.gameObject);
        }
    }
}