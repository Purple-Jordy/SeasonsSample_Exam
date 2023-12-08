using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Candle : MonoBehaviour, IInteractable
{

    private Inventory inventory;
    private SaveAndLoad theSaveAndLoad;

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
    }


    private void Update()
    {
        if (candleFire)
        {
            fireAnim.enabled = true;
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



