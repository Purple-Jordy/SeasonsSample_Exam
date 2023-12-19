using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour, IInteractable
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
        if(animator.GetBool("ValveTurnOn") == true)
        {
            animator.SetBool("ValveTurnOn", false);
        }
        else
        {
            animator.SetBool("ValveTurnOn", true);
        }

        //효과음 플레이
        AudioManager.Instance.Play("lightOnOff");
    }

    
}
