 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class fireplace : MonoBehaviour, IInteractable
{
    #region PickUpItem
    public Item item;

    private GameObject InventorySlots;
    private TextMeshProUGUI itemText;
    private GameObject itemNameUI;
    #endregion

    #region lockItem
    private Inventory inventory;

    //사용 아이템 이름(사용 잠금 해제)
    public string UnlockItem1; 
    public string UnlockItem2;

    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;
    #endregion

    private SaveAndLoad theSaveAndLoad;

    private Animator animator;
    public static bool IsFire = false;
    public static bool woodHere = false;
    

    void Start()
    {

        itemNameUI = GameObject.Find("ItemNameUI");
        itemText = itemNameUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        inventory = Inventory.Instance;
        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        animator = GetComponent<Animator>();
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
    }


    private void Update()
    {
        if (woodHere)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }

        if(IsFire)
        {
            animator.enabled = true;
        }
    }


    public void interact(DisplayImage currentDisplay)
    {
        // 나무가 없는 상태라면
        if (this.GetComponent<SpriteRenderer>().enabled == false)
        {
            //선택한 슬롯이 나무면
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem1)
            {
                if (inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    //슬롯에 있는 나무 사용
                    UseItem();
                    woodHere = true;
                }
                   
            }


            //나무가 없는 상태에서 선택한 슬롯이 성냥이면
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2)
            {
                if (inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    // "나무 없음" 나오게
                    UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                    situationText.text = "나무 없음";
                }
            }


        }
        else //나무가 있으면 성냥과 상호작용
        {
            
            //선택한 슬롯이 성냥이면
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2)
            {
                if (inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    //불 타는 애니메이션 재생
                    animator.enabled = true;
                    IsFire = true;
                    theSaveAndLoad.SaveData();
                }
            }
            else // 선택한 슬롯이 성냥이 아니면
            {
                if (IsFire) // 불이 있으면
                {
                    // 아무 일도 일어나지 않는다
                }
                else
                {
                    //불도 없으면 
                    // 나무 다시 집기
                    CanPickUpOff();
                    woodHere = false;
                }

            }
        }

        

    }


    // 슬롯에 있는 아이템 사용
    public void UseItem()
    {
        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); //슬롯 비우기
        this.GetComponent<SpriteRenderer>().enabled = true;

    }

    
    // 아이템 획득 & 데이터 저장
    public void CanPickUpOff()
    {
        inventory.AcquireItem(item);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //theSaveAndLoad.SaveData();
    }

}
