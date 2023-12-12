using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class kitchenPot : MonoBehaviour, IInteractable
{


    
    private GameObject InventorySlots;
    private TextMeshProUGUI itemText;
    private GameObject itemNameUI;


    //
    public string UnlockItem;
    //잠금해제 아이템(이 아이템이 있어야 잠금해제)

    private Inventory inventory;
    private SaveAndLoad theSaveAndLoad;

    private GameObject situationUI;
    private Animator animator;
    private TextMeshProUGUI situationText;

    private sinkWater sinkWater;
    public GameObject PotInkitchen;

    public static bool waterInPot;
    public static bool potOnSink = false;

    public Item item;


    private void Start()
    {
        itemNameUI = GameObject.Find("ItemNameUI");
        itemText = itemNameUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        inventory = Inventory.Instance;
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();

        situationUI = GameObject.Find("situationUI");
        animator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        sinkWater = GameObject.Find("sinkenter").GetComponent<sinkWater>();
    }


    private void Update()
    {
        // 싱크대 위에 냄비가 있는 경우
        if(this.GetComponent<SpriteRenderer>().enabled == true)
        {
            // 냄비 안에 물을 부으면
            if (sinkWater.waterFlow == true)
            {
                //itemText.text = item.changeText; //물이 든 냄비
                waterInPot = true;
            }

            //냄비를 싱크대 위에 두고 화면을 벗어날 경우
            //PotInkitchen.SetActive(true);
        }
        else //냄비를 획득한 경우
        {
            //PotInkitchen.SetActive(false);
        }


        //수전과 interaction이 겹치기 때문에 냄비를 선택했을 때만 박스콜라이더가 보이게 한다.  
        
        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem
            && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }


        if (potOnSink) //저장 관련
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }


        
    }



    public void interact(DisplayImage currentDisplay)
    {
       // 1. 스프라이트 렌더러 off, 슬롯에 없는 상태 : 클릭해도 아무런 반응 X
       // 2. 스프라이트 렌더러 off, 슬롯의 냄비가 클릭된 상태: 스프라이트 렌더러 On
       // 3. 스프라이트 렌더러 on, 슬롯에 없는 상태 : 슬롯에 생성, 렌더러 다시 off

        // 냄비 관련
        if(this.GetComponent<SpriteRenderer>().enabled == false) 
        { 
            if(inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
            {
               if(inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
               {
                    //인벤토리에 있는 냄비 사용
                    UseItem();
                    potOnSink = true;
                }
                
            }
        }
        else //this.GetComponent<SpriteRenderer>().enabled == true
        {
            // 냄비 획득
            ItemPickUp();
            potOnSink = false;
        }

    }



    // 픽업 함수(아이템 획득)
    public void ItemPickUp()
    {

        Inventory.Instance.AcquireItem(item);

        //클릭한 아이템 삭제
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;

        inventory.currentSelectedSlot = inventory.previousSelectedSlot;
        inventory.previousSelectedSlot = inventory.currentSelectedSlot;


        /*if (waterInPot == true)
        {
            itemText.text = item.changeText; //물이 든 냄비

        }*/
    }


    // 아이템 사용
    public void UseItem()
    {
        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); //슬롯 비우기
        this.GetComponent<SpriteRenderer>().enabled = true;
  
    } 

}
