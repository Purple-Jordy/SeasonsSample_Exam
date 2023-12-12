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

    //��� ������ �̸�(��� ��� ����)
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
        // ������ ���� ���¶��
        if (this.GetComponent<SpriteRenderer>().enabled == false)
        {
            //������ ������ ������
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem1)
            {
                if (inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    //���Կ� �ִ� ���� ���
                    UseItem();
                    woodHere = true;
                }
                   
            }


            //������ ���� ���¿��� ������ ������ �����̸�
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2)
            {
                if (inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    // "���� ����" ������
                    UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                    situationText.text = "���� ����";
                }
            }


        }
        else //������ ������ ���ɰ� ��ȣ�ۿ�
        {
            
            //������ ������ �����̸�
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2)
            {
                if (inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    //�� Ÿ�� �ִϸ��̼� ���
                    animator.enabled = true;
                    IsFire = true;
                    theSaveAndLoad.SaveData();
                }
            }
            else // ������ ������ ������ �ƴϸ�
            {
                if (IsFire) // ���� ������
                {
                    // �ƹ� �ϵ� �Ͼ�� �ʴ´�
                }
                else
                {
                    //�ҵ� ������ 
                    // ���� �ٽ� ����
                    CanPickUpOff();
                    woodHere = false;
                }

            }
        }

        

    }


    // ���Կ� �ִ� ������ ���
    public void UseItem()
    {
        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); //���� ����
        this.GetComponent<SpriteRenderer>().enabled = true;

    }

    
    // ������ ȹ�� & ������ ����
    public void CanPickUpOff()
    {
        inventory.AcquireItem(item);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //theSaveAndLoad.SaveData();
    }

}
