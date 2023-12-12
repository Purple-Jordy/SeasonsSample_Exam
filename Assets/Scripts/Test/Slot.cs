using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler //����Ƽ �����Լ�
{
    private GameObject itemNameUI;
    private TextMeshProUGUI itemUIText;

    public Item item; // ȹ���� ������

    private GameObject slotItem;
    public bool chooseItem = false;


    private Inventory inventory;
    private GameObject slotBackground;
    private SaveAndLoad theSaveAndLoad;


    private void Start()
    {
        slotItem = this.transform.GetChild(0).gameObject;

        itemUIText = GameObject.Find("displayText").GetComponent<TextMeshProUGUI>();
        itemNameUI = GameObject.Find("ItemNameUI");

        inventory = Inventory.Instance;
        slotBackground = GameObject.Find("SlotBackground");
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();

    }




    // �κ��丮�� ���ο� ������ ���� �߰�
    public void AddItem(Item _item)
    {
        item = _item; //������
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Inventory Items/{item.itemName}"); //������ �̹���

        slotItem.GetComponent<Animator>().SetTrigger("getItem");

        // ������ �̸� �����ֱ�
        //Ŭ���� �� �ִϸ��̼� ó������ ���
        itemNameUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);

        //�ؽ�Ʈ �̸� ����
        if (item.itemName == "pot")
        {
            if (kitchenPot.waterInPot) // ���� ���� ��� ������
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
            if (ovenPot.eggRipe) // ���� ���� ����
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


    // �ش� ���� �ϳ� ����
    public void ClearSlot()
    {
        item = null;
      
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");

        chooseItem = false;

        theSaveAndLoad.SaveData(); // �������� ����� ������ ����
    }



    //Ŭ�� �̺�Ʈ
    public void OnPointerClick(PointerEventData eventData)
    {
        // �������� �ִ� ����
        if (item != null) 
        {
            // ���� X ����
            if (!chooseItem)
            {
                // ������ ���缱�õ� ������ �� ��ũ��Ʈ�� ���� ����
                inventory.previousSelectedSlot = inventory.currentSelectedSlot;
                inventory.currentSelectedSlot = this.gameObject;

                // ������ �̸� �����ֱ�
                //Ŭ���� �� �ִϸ��̼� ó������ ���
                itemNameUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);

                //�ؽ�Ʈ �̸� ����
                //itemUIText.text = item.itemText;
                if (item.itemName == "pot")
                {
                    if (kitchenPot.waterInPot) // ���� ���� ��� ������
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
                    if (ovenPot.eggRipe) // ���� ���� ����
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
            else //���õ� ���¸� ���ֱ�
            {
                chooseItem = false;
            }

        }
        else // Ŭ���� ���Կ� �������� ���ٸ�
        {
            inventory.previousSelectedSlot = inventory.currentSelectedSlot;
            inventory.currentSelectedSlot = this.gameObject;

            if (inventory.previousSelectedSlot.GetComponent<Slot>().item != null)
            {

                ChangeSlot();

            }


            ChangeSlot();
        }
    
    
     }


    private void ChangeSlot()
    {

        this.transform.GetChild(0).GetComponent<Animator>().SetTrigger("getItem");
        Slot pre = inventory.previousSelectedSlot.GetComponent<Slot>();

        AddItem(pre.item);

        // ������ �̸� �����ֱ�
        //Ŭ���� �� �ִϸ��̼� ó������ ���
        itemNameUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);

        //�ؽ�Ʈ �̸� ����
        //itemUIText.text = item.itemText;
        if (item.itemName == "pot")
        {
            if (kitchenPot.waterInPot) // ���� ���� ��� ������
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
            if (ovenPot.eggRipe) // ���� ���� ����
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

        theSaveAndLoad.SaveData(); // �ٲ� ���� ����
    }






}
