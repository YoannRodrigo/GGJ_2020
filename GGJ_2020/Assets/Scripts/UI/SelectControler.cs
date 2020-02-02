using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class SelectControler : MonoBehaviour
{
    public List<Transform> framesPosition = new List<Transform>();
    private List<string> objectToolNamesRemove = new List<string>(9) {"Plug","Nail","Button","Stain","Flipper","Antenna","Screw","Banana", "Sparadras"};
    private string currentTool;
    private int currentIndex;
    public bool canbeMoved;
    private bool isPositionReset = true;

    public string GetCurrentTool()
    {
        return currentTool;
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
        }
    }
}
