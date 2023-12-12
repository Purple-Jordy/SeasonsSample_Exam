using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkHandleLeft : MonoBehaviour, IInteractable
{
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool waterOn = false;

    private SaveAndLoad theSaveAndLoad;

    void Start()
    {
        animator = GameObject.Find("sink").GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
    }


    public void interact(DisplayImage currentDisplay)
    {
        // 클릭 애니메이션
        animator.SetTrigger("waterOn");

        // 손잡이 모양 변경
        StartCoroutine(sinkAnim());

    }


    IEnumerator sinkAnim()
    {
        //클릭 애니메이션 재생 후 손잡이 이미지 변경

        yield return new WaitForSeconds(0.3f);

        if (waterOn) //true/false 상태에 따라 손잡이 모양 바꿔주기
        {
            this.spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/sink4");
            waterOn = false;
        }
        else
        {
            this.spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/sink6");
            waterOn = true;

            //물을 틀면 저장
            if (kitchenPot.potOnSink)
            {
                theSaveAndLoad.SaveData();
            }
        }
    }


}
