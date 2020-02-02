#region

using UnityEngine;

#endregion

public class GameCanvasManager : MonoBehaviour
{
    public int currentNbHoleFix;

    public int currentNbHoleMax;
    public SelectControler leftController;
    public SelectControler rightController;

    public bool IsLeftActive()
    {
        return leftController.canbeMoved;
    }

    public bool IsRightActive()
    {
        return rightController.canbeMoved;
    }

    public string GetCurrentLeftTool()
    {
        return leftController.GetCurrentTool();
    }

    public string GetCurrentRightTool()
    {
        return rightController.GetCurrentTool();
    }
}