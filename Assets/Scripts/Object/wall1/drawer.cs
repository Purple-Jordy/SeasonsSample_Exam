using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class drawer : MonoBehaviour, IInteractable
{
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnEnable()
    {
        animator.Rebind();
    }


    public void interact(DisplayImage currentDisplay)
    {

        if (animator.GetBool("IsOpen") == false)
        {
            animator.SetBool("IsOpen", true);

        }
        else if (animator.GetBool("IsOpen") == true)
        {
            animator.SetBool("IsOpen", false);
        }

    }

}
