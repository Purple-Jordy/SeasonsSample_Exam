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


    // 클릭하면 아이템 픽업
    public override void interact(DisplayImage currentDisplay)
    {
        //base.interact(currentDisplay);
        StartCoroutine(GetPhoto1());
    }


    IEnumerator GetPhoto1()
    {
        animator.SetTrigger("Click");

        yield return new WaitForSeconds(1f);

        CanPickUp();
    }
   
}

    

