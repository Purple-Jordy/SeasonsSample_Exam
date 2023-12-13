using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler //유니티 지원함수
{
    private GameObject itemNameUI;
    private TextMeshProUGUI itemUIText;

    public Item item; // 획득한 아이템

    private GameObject slotItem;
    public bool chooseItem = false;


    private Inventory inventory;
    private GameObject slotBackground;
    private SaveAndLoad theSaveAndLoad;


    private void Start()
    {
        slotItem = this.transform.GetChild(0).gameObject; //자신의 자식(item)

        
        itemNameUI = GameObject.Find("ItemNameUI");
        itemUIText = GameObject.Find("ItemNameUI").transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        inventory = Inventory.Instance;
        slotBackground = GameObject.Find("SlotBackground");
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();

    }




    // 인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item)
    {
        item = _item; //아이템
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Inventory Items/{item.itemName}"); //아이템 이미지

        slotItem.GetComponent<Animator>().SetTrigger("getItem");

        // 아이템 이름 보여주기
        //클릭될 때 애니메이션 처음부터 재생
        itemNameUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);

        //텍스트 이름 설정
        if (item.itemName == "pot")
        {
            if (kitchenPot.waterInPot) // 냄비에 물이 들어 있으면
            {
                itemUIText.text = item.changeText;
            }
            else
            {
                itemUIText.text = item.itemText;
            }
        }
        else if (item.itemName == "egg")
        {
            if (ovenPot.eggRipe) // 알이 익은 상태
            {
                itemUIText.text = item.changeText;
            }
            else
            {
                itemUIText.text = item.itemText;
            }
        }
        else
        {
            itemUIText.text = item.itemText;
        }

        //itemUIText.text = item.itemText;

        //theSaveAndLoad.SaveData();
    }



    // 해당 슬롯 하나 삭제
    public void ClearSlot()
    {
        item = null;
      
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");

        chooseItem = false;

        theSaveAndLoad.SaveData(); // 아이템을 사용할 때마다 저장
    }



    //클릭 이벤트
    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭한 슬롯에 아이템이 있는 상태
        if (item != null) 
        {
            // 선택 X 상태
            if (!chooseItem)
            {
                // 이전에 현재선택된 슬롯은 이 스크립트가 붙은 슬롯
                inventory.previousSelectedSlot = inventory.currentSelectedSlot;
                inventory.currentSelectedSlot = this.gameObject;

                // 아이템 이름 보여주기
                //클릭될 때 애니메이션 처음부터 재생
                itemNameUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);

                //텍스트 이름 설정
                //itemUIText.text = item.itemText;
                if (item.itemName == "pot")
                {
                    if (kitchenPot.waterInPot) // 냄비에 물이 들어 있으면
                    {
                        itemUIText.text = item.changeText;
                    }
                    else
                    {
                        itemUIText.text = item.itemText;
                    }
                }
                else if (item.itemName == "egg")
                {
                    if (ovenPot.eggRipe) // 알이 익은 상태
                    {
                        itemUIText.text = item.changeText;
                    }
                    else
                    {
                        itemUIText.text = item.itemText;
                    }
                }
                else
                {
                    itemUIText.text = item.itemText;
                }


                chooseItem = true;


            }
            else //선택된 상태면 꺼주기
            {
                chooseItem = false;
            }

        }
        else // 클릭한 슬롯에 아이템이 없다면
        {
            

            //만약 이전의 슬롯에 아이템이 있었다면 자리를 바꿔준다
            if (inventory.previousSelectedSlot.GetComponent<Slot>().item != null)
            {
                inventory.previousSelectedSlot = inventory.currentSelectedSlot;
                inventory.currentSelectedSlot = this.gameObject;

                ChangeSlot();

            }

            //다른 걸 클릭하면 선택해제
            chooseItem = false;
            slotItem.GetComponent<Animator>().SetTrigger("getItem");

        }
    
    
     }


    // 슬롯 바꾸기
    private void ChangeSlot()
    {

        this.transform.GetChild(0).GetComponent<Animator>().SetTrigger("getItem");
        Slot pre = inventory.previousSelectedSlot.GetComponent<Slot>();

        AddItem(pre.item);

        // 아이템 이름 보여주기
        //클릭될 때 애니메이션 처음부터 재생
        itemNameUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);

        //텍스트 이름 설정
        //itemUIText.text = item.itemText;
        if (item.itemName == "pot")
        {
            if (kitchenPot.waterInPot) // 냄비에 물이 들어 있으면
            {
                itemUIText.text = item.changeText;
            }
            else
            {
                itemUIText.text = item.itemText;
            }
        }
        else if (item.itemName == "egg")
        {
            if (ovenPot.eggRipe) // 알이 익은 상태
            {
                itemUIText.text = item.changeText;
            }
            else
            {
                itemUIText.text = item.itemText;
            }
        }
        else
        {
            itemUIText.text = item.itemText;
        }

        pre.ClearSlot();

        if (slotBackground.GetComponent<Animator>().GetBool("InvenOpen") == true)
        {
            slotBackground.GetComponent<Animator>().SetBool("InvenOpen", false);
        }

        //theSaveAndLoad.SaveData(); // 바뀐 슬롯 저장
    }


    // 인벤토리에 새로운 아이템 슬롯 추가
    public void LoadItem(Item _item)
    {
        item = _item; //아이템
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Inventory Items/{item.itemName}"); //아이템 이미지


        //텍스트 이름 설정
        if (item.itemName == "pot")
        {
            if (kitchenPot.waterInPot) // 냄비에 물이 들어 있으면
            {
                itemUIText.text = item.changeText;
            }
            else
            {
                itemUIText.text = item.itemText;
            }
        }
        else if (item.itemName == "egg")
        {
            if (ovenPot.eggRipe) // 알이 익은 상태
            {
                itemUIText.text = item.changeText;
            }
            else
            {
                itemUIText.text = item.itemText;
            }
        }
        else
        {
            itemUIText.text = item.itemText;
        }

    }



}
