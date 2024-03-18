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

    public Item item; // ȹ���� ������(�ּ�)

    private GameObject slotItem; // ���� ���� ������(UI ����)
    public bool chooseItem = false; //���� �� ������ Ŭ���Ͽ��°�


    private Inventory inventory;
    private GameObject slotBackground;
    private SaveAndLoad theSaveAndLoad;


    private void Start()
    {
        slotItem = this.transform.GetChild(0).gameObject; //�ڽ��� �ڽ�(item)

        itemNameUI = GameObject.Find("ItemNameUI");
        itemUIText = GameObject.Find("ItemNameUI").transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        inventory = Inventory.Instance;
        slotBackground = GameObject.Find("SlotBackground"); // ���� ���ȭ��
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();

    }


    // �κ��丮�� ���ο� ������ ���� �߰�
    public void AddItem(Item _item)
    {
        item = _item; //������

        // ���Կ� ������ �̹��� �ֱ�
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Inventory Items/{item.itemName}"); 

        // ������ ȹ�� ���� �ִϸ��̼� ���
        slotItem.GetComponent<Animator>().SetTrigger("getItem");

        //ȿ���� �÷���
        AudioManager.Instance.Play("GetItem");

        //������ �̸� �����ֱ�(UI �ִϸ��̼� ó������ ��� - �������� ������ ȹ���ϸ� �ִϸ��̼��� ���ϴ� Ÿ�ֿ̹� ��� �� �Ǳ� ������)
        itemNameUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);

        //ȹ���� ������ ���¿� ���� ������ ���� �ؽ�Ʈ UI �̸� ����
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


    }


    // ���Կ� �ִ� ������ ���� ����(������ ���)
    public void ClearSlot()
    {
        item = null;
        
        // ���� ������ �̹��� ����ִ� �̹����� ����
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");

        chooseItem = false;

        theSaveAndLoad.SaveData(); // �������� ����� ������ ����
    }



    //Ŭ�� �̺�Ʈ(�� ������ Ŭ���Ͽ��°�)
    public void OnPointerClick(PointerEventData eventData)
    {
        // Ŭ���� ���Կ� �������� �ִٸ�
        if (item != null) 
        {
            // ������ ���� X ���¶��
            if (!chooseItem)
            {
                //���� Ŭ�� ���� ������Ʈ
                inventory.previousSelectedSlot = inventory.currentSelectedSlot;
                inventory.currentSelectedSlot = this.gameObject;

                //������ �̸� �����ֱ�(UI �ִϸ��̼� ó������ ���)
                itemNameUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);

                //ȹ���� ������ ���¿� ���� ������ ���� �ؽ�Ʈ UI �̸� ����
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

                // ���� ���� ������Ʈ 
                chooseItem = true;

                //ȿ����
                AudioManager.Instance.Play("chooseItem");

            }
            else //���õ� ���¸� ���ֱ�
            {
                //�̹� ���õ� ������ �� Ŭ���ߴٸ� Ŭ�� ���¸� ���ش�
                chooseItem = false;
            }

        }
        else // Ŭ���� ���Կ� �������� ���ٸ�
        {
            
            //���� ������ Ŭ���� ���Կ� �������� �־��ٸ� �� �������� �ڸ��� �ٲ��ش�
            if (inventory.previousSelectedSlot.GetComponent<Slot>().item != null)
            {
                inventory.previousSelectedSlot = inventory.currentSelectedSlot;
                inventory.currentSelectedSlot = this.gameObject;

                ChangeSlot();

            }

            //�ٸ� �� Ŭ���ϸ� ��������
            chooseItem = false;
            slotItem.GetComponent<Animator>().SetTrigger("getItem");

        }
    
    
     }


    // ���� �ٲٱ�
    private void ChangeSlot()
    {
        
        //���� ������ ������ �����ͼ�
        Slot pre = inventory.previousSelectedSlot.GetComponent<Slot>();


        // ���� ������ Ŭ���� ���¿��� �Ѵ�
        if(pre.chooseItem == true)
        {
            // ���� ���Կ� �����´�
            AddItem(pre.item);

            //���� ������ ������ ���ش�
            pre.ClearSlot();

            //���� �ι�° ���� ĭ�� ���������� �ݾ��ش�
            if (slotBackground.GetComponent<Animator>().GetBool("InvenOpen") == true)
            {
                slotBackground.GetComponent<Animator>().SetBool("InvenOpen", false);
            }
        }

    }


    // ������ ������ �ҷ����� 
    public void LoadItem(Item _item)
    {
        item = _item; //������

        // ���� ������ �̹��� ����
        this.slotItem.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Inventory Items/{item.itemName}"); 
        

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

    }



}
