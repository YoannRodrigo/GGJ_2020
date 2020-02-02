#region

using UnityEngine;

#endregion

[RequireComponent(typeof(Animator))]
public class CanvasController : MonoBehaviour
{
    private static readonly int framesRightIn = Animator.StringToHash("FramesRightIn");
    private static readonly int framesLeftIn = Animator.StringToHash("FramesLeftIn");
    private Animator animator;
    private bool isSoundPlayed;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("LeftButton"))
        {
            if(!isSoundPlayed)
            {
                isSoundPlayed = true;
                AkSoundEngine.PostEvent("LB_RB", Camera.main.gameObject);
            }
            animator.SetBool(framesRightIn, false);
            animator.SetBool(framesLeftIn, true);
        }

        if (Input.GetButton("RightButton"))
        {
            if(!isSoundPlayed)
            {
                isSoundPlayed = true;
                AkSoundEngine.PostEvent("LB_RB", Camera.main.gameObject);
            }
            animator.SetBool(framesRightIn, true);
            animator.SetBool(framesLeftIn, false);
        }

        if (!Input.anyKey)
        {
            isSoundPlayed = false;
        }
    }
}