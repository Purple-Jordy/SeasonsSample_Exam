using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Candle : MonoBehaviour, IInteractable
{

    private Inventory inventory;
    private SaveAndLoad theSaveAndLoad;

    // 줌 상태 확인
    private DisplayImage currentDisplay;

    private Animator animator;
    private Animator fireAnim;

    // 상호작용할 아이템 이름
    public string UnlockItem;
    public static bool candleFire = false;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        fireAnim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();

        inventory = Inventory.Instance;
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    private void Update()
    {
        // 저장 관련 : 촛불에 불을 붙였음
        if (candleFire)
        {
            fireAnim.enabled = true;
        }

        //줌 화면일때만 콜라이더를 켜준다
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        else // 줌이 아니면 꺼준다
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }


    public void interact(DisplayImage currentDisplay)
    {

        //화면이 zoom 상태일때만 움직이게
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            //양초 선택 애니메이션
            animator.SetTrigger("click");

            // 성냥이 있으면
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
            {
                if (inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    // 불 애니메이션 재생
                    //fireAnim.enabled = true;
                    candleFire = true;
                    theSaveAndLoad.SaveData();
                }

            }
        }
    }


}



