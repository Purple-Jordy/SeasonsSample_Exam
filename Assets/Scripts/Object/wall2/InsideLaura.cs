using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideLaura : MonoBehaviour, IInteractable
{

    private Animator animator;


    
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void interact(DisplayImage currentDisplay)
    {
        animator.SetBool("ClickLaura", true);
    }

}
