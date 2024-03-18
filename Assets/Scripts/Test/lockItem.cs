using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lockItem : MonoBehaviour, IInteractable
{

    #region lockItem
    private Inventory inventory;
    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;

    public string UnlockItem; //잠금해제 아이템(이 아이템이 있어야 잠금해제)

    //아이템 없을 시 나오는 글씨
    [SerializeField]
    private string lockText = "잠김";
    #endregion

    public void Start()
    {
        inventory = Inventory.Instance;
        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }


    //클릭 이벤트
    public void interact(DisplayImage currentDisplay)
    {

        ItemUnlock();

    }


    public virtual void ItemUnlock()
    {
        //인벤토리의 현재 선택된 슬롯의 스프라이트 이름이 언록아이템 이름과 같으면 
        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            Debug.Log("unlock"); // 잠금해제
            //inven.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); //슬롯 비우기
        }
        else
        {
            UIAnimator.Play("ShowItemNameAnim", -1, 0f);
            situationText.text = lockText;
            //효과음 플레이
            AudioManager.Instance.Play("locked");
        }
    }
}
