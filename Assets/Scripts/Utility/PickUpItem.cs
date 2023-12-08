using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour, IInteractable
{
    #region PickUpItem
    public enum property { usable, displayable };

    public string DisplaySprite; //아이템 이미지
    public string DisplayImage; //슬롯 클릭시 보여줄 이미지
    public string CombinationItem; 
    public string DisplayText; //텍스트 이름

    

    public property itemProperty;

    private GameObject InventorySlots;
    private TextMeshProUGUI itemText;
    private GameObject itemNameUI;
    #endregion


    // 클릭하면 아이템 픽업
    public void interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
    }


    public virtual void Start()
    {
        itemNameUI = GameObject.Find("ItemNameUI");
        itemText = itemNameUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }


    // 픽업 함수
    public virtual void ItemPickUp()
    {
        InventorySlots = GameObject.Find("Slots");


        foreach (Transform slot in InventorySlots.transform)
        {
            //슬롯의 자식 iteam의 스프라이트 이름이 empty라면(empty인 곳에 찾아서 넣기)
            if(slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Animator>().SetTrigger("getItem");

                //item의 스프라이트 이름으로 설정
                slot.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);

                //슬롯에 아이템 속성 부여
                //slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage, CombinationItem, DisplayText);

                //아이템 획득했을 때 이름 보여주기
                itemNameUI.GetComponent<Animator>().SetTrigger("ShowName");
                itemText.text = DisplayText;

                //클릭한 아이템 삭제
                ItemDestroy();

                break;
            }

            
        }
    }


    public virtual void ItemDestroy()
    {
        Destroy(gameObject);
    }

}
