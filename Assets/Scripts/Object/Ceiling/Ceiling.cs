using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Ceiling : MonoBehaviour, IInteractable // 인터페이스 상속
{

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        // 자식(픽업할 아이템)이 있다면 
        if (this.transform.childCount != 0)
        {
            // 조명이 on 상태일 때만 보이게
            if (LightSwitch.lightOn == true) 
            {
                //자식의 오브젝트 켜주기
                this.transform.GetChild(0).gameObject.SetActive(true);

                // 불러오기 관련 : 사진을 얻은 상태면 오브젝트 파괴하기
                if (Photo.getPhoto1)
                {
                    Destroy(this.transform.GetChild(0).gameObject);
                }
            }
            
        }
        
    }


    // 인터페이스 상속
    //클릭 이벤트 : 1. 클릭 할 때마다 애니메이션 재생 2. 자식(아이템) 획득
    public void interact(DisplayImage currentDisplay)
    {
        //클릭할 때마다 천장 전등 애니메이션 재생
        animator.SetTrigger("IsClick");

        // 자식(픽업할 아이템)이 있다면 
        if (this.transform.childCount != 0)
        {
            //자식이 active 상태라면 아이템 획득
            if (this.transform.GetChild(0).gameObject.activeSelf)
            {
                this.transform.GetChild(0).GetComponent<ItemPickUp>().CanPickUp();
            }

        }
    }


}
