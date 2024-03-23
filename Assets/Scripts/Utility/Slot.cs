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

    public Item item; // 획득한 아이템(애셋)

    private GameObject slotItem; // 슬롯 위에 아이템(UI 관련)
    public bool chooseItem = false; //지금 이 슬롯을 클릭하였는가


    private Inventory inventory;
    private GameObject slotBackground;
    private SaveAndLoad theSaveAndLoad;


    private void Start()
    {
        slotItem = this.transform.GetChild(0).gameObject; //자신의 자식(item)

        itemNameUI = GameObject.Find("ItemNameUI");
        itemUIText = GameObject.Find("ItemNameUI").transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        inventory = Inventory.Instance;
        slotBackground = GameObject.Find("SlotBackground"); // 슬롯 배경화면
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();

    }


    // 인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item)
    {
        item = _item; //아이템

        // 슬롯에 아이템 이미지 넣기
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Inventory Items/{item.itemName}"); 

        // 아이템 획득 슬롯 애니메이션 재생
        slotItem.GetComponent<Animator>().SetTrigger("getItem");

        //효과음 플레이
        AudioManager.Instance.Play("GetItem");

        //아이템 이름 보여주기(UI 애니메이션 처음부터 재생 - 아이템을 빠르게 획득하면 애니메이션이 원하는 타이밍에 재생 안 되기 때문에)
        itemNameUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);

        //획득한 아이템 상태와 저장 정보에 따라 텍스트 UI 이름 설정
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


    // 슬롯에 있는 아이템 정보 삭제(아이템 사용)
    public void ClearSlot()
    {
        item = null;
        
        // 슬롯 아이템 이미지 비어있는 이미지로 변경
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");

        chooseItem = false;

        theSaveAndLoad.SaveData(); // 아이템을 사용할 때마다 저장
    }



    //클릭 이벤트(이 슬롯을 클릭하였는가)
    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭한 슬롯에 아이템이 있다면
        if (item != null) 
        {
            // 이전에 선택 X 상태라면
            if (!chooseItem)
            {
                //슬롯 클릭 상태 업데이트
                inventory.previousSelectedSlot = inventory.currentSelectedSlot;
                inventory.currentSelectedSlot = this.gameObject;

                //아이템 이름 보여주기(UI 애니메이션 처음부터 재생)
                itemNameUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);

                //획득한 아이템 상태와 저장 정보에 따라 텍스트 UI 이름 설정
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

                // 선택 상태 업데이트 
                chooseItem = true;

                //효과음
                AudioManager.Instance.Play("chooseItem");

            }
            else //선택된 상태면 꺼주기
            {
                //이미 선택된 슬롯을 또 클릭했다면 클릭 상태를 꺼준다
                chooseItem = false;
            }

        }
        else // 클릭한 슬롯에 아이템이 없다면
        {
            
            //만약 이전에 클릭한 슬롯에 아이템이 있었다면 이 슬롯으로 자리를 바꿔준다
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
        
        //이전 슬롯의 정보를 가져와서
        Slot pre = inventory.previousSelectedSlot.GetComponent<Slot>();


        // 이전 슬롯이 클릭된 상태여야 한다
        if(pre.chooseItem == true)
        {
            // 지금 슬롯에 가져온다
            AddItem(pre.item);

            //이전 슬롯의 내용을 없앤다
            pre.ClearSlot();

            //만약 두번째 슬롯 칸이 열려있으면 닫아준다
            if (slotBackground.GetComponent<Animator>().GetBool("InvenOpen") == true)
            {
                slotBackground.GetComponent<Animator>().SetBool("InvenOpen", false);
            }
        }

    }


    // 아이템 데이터 불러오기 
    public void LoadItem(Item _item)
    {
        item = _item; //아이템

        // 슬롯 아이템 이미지 설정
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Inventory Items/{item.itemName}"); 
        

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
