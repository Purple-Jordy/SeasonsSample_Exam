using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Photo3 : ItemPickUp
{

    private Animator animator;


    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        
    }


    private void Update()
    {
        if (Photo.getPhoto3)
        {
            Destroy(this.gameObject);
        }    
    }


    // Ŭ���ϸ� ������ �Ⱦ�
    public override void interact(DisplayImage currentDisplay)
    {
        base.interact(currentDisplay);
        animator.SetTrigger("Click");
    }

   
}

    
