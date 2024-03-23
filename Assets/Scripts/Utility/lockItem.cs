using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lockItem : MonoBehaviour, IInteractable //인터페이스
{

    #region lockItem
    private Inventory inventory;
    private GameObject situationUI; // 상황 글씨 UI 
    private Animator UIAnimator; // 상황 글씨 UI 애니메이션
    private TextMeshProUGUI situationText; // 상황 글씨 UI 텍스트

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


    //클릭 이벤트(클릭할 시)
    public void interact(DisplayImage currentDisplay)
    {

        ItemUnlock(); // 필요한 아이템을 확인해서 잠김/열림 표시

    }


    public virtual void ItemUnlock()
    {
        //인벤토리의 현재 선택된 슬롯의 스프라이트 이름이 언록아이템 이름과 같으면 
        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            Debug.Log("unlock"); // 잠금해제
        }
        else
        {
            UIAnimator.Play("ShowItemNameAnim", -1, 0f); //잠김 글씨 애니메이션

            situationText.text = lockText; //잠김 글씨 

            //효과음 플레이
            AudioManager.Instance.Play("locked");
        }
    }
}
