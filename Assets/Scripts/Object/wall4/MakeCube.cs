using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MakeCube : MonoBehaviour, IInteractable
{
    //메모 내용 보이기
    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;

    private Inventory inventory;

    // 벽난로 불 확인
    //private fireplace fireplace;

    // 줌 상태 확인
    private DisplayImage currentDisplay;

    // 큐브 애니메이션
    private Animator animator;

    // 상호작용할 아이템 이름
    public string UnlockItem;

    public static bool cubeHere = false;


    void Start()
    {
        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        inventory = Inventory.Instance;

        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        //fireplace = GameObject.Find("fireplace").GetComponent<fireplace>();

        animator = GetComponent<Animator>();

    }


    private void Update()
    {
        //줌 화면이 아니면
        if (currentDisplay.CurrentState != DisplayImage.State.zoom) 
        {
            if (cubeHere == true)
            {
                animator.SetBool("cubeHere", true);

            }

            //불 애니메이션은 꺼주기
            animator.SetBool("IsFire", false);
            

        }
        else //줌 상태
        {
            
            //줌 화면이고 불이 있으면 불 애니메이션 재생
            if (fireplace.IsFire == true)
            {
                animator.SetBool("IsFire", true);
            }

            if (cubeHere == true)
            {
                animator.SetBool("cubeHere", true);

            }

            // IsFire, cubeHere 둘 다 true라서 불+큐브 애니메이션 재생
        }

    }


    public void interact(DisplayImage currentDisplay)
    {
        //화면이 zoom 상태일 때만 글씨 나오게 
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            //선택한 슬롯이 검은 큐브면 검은 큐브 사용해주기 
            if(inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem
                && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {
                cubeHere = true;
                UseItem();
                AudioManager.Instance.Play("cubeInWall");
            }
            else if (cubeHere == true)
            {
                UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                situationText.text = "큐브를 놓았는데";
            }
            else if (cubeHere == false)
            {
                UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                situationText.text = "이게 뭐지?";
            }
            
        }
    }


    public void UseItem()
    {

        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); // 슬롯비우기 

    }


}
