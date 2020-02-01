using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CanvasController : MonoBehaviour
{
    private Animator animator;
    private static readonly int framesRightIn = Animator.StringToHash("FramesRightIn");
    private static readonly int framesLeftIn = Animator.StringToHash("FramesLeftIn");

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButton("LeftButton"))
        {
            animator.SetBool(framesRightIn,false);
            animator.SetBool(framesLeftIn, true);
        }
        
        if(Input.GetButton("RightButton"))
        {
            animator.SetBool(framesRightIn,true);
            animator.SetBool(framesLeftIn, false);
        }
    }
}
