using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimatorControllerScript : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        animator.SetTrigger("TrRotete");
    }

    public void PauseAnimation()
    {
        animator.speed = 0; 
    }

    public void ResumeAnimation()
    {
        animator.speed = 0.3f; 
    }
}

