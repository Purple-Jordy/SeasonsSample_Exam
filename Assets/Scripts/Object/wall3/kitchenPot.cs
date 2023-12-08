using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class kitchenPot : MonoBehaviour, IInteractable
{


    
    private GameObject InventorySlots;
    private TextMeshProUGUI itemText;
    private GameObject itemNameUI;

    //private bool waterInPot = false;

    //
    public string UnlockItem;
    //������� ������(�� �������� �־�� �������)

    private Inventory inventory;

    private GameObject situationUI;
    private Animator animator;
    private TextMeshProUGUI situationText;

    private sinkWater sinkWater;
    public GameObject PotInkitchen;

    public bool waterInPot;

    public Item item;


    private void Start()
    {
        itemNameUI = GameObject.Find("ItemNameUI");
        itemText = itemNameUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        inventory = Inventory.Instance;

        situationUI = GameObject.Find("situationUI");
        animator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        sinkWater = GameObject.Find("sinkenter").GetComponent<sinkWater>();
    }


    private void Update()
    {
        // ��ũ�� ���� ���� �ִ� ���
        if(this.GetComponent<SpriteRenderer>().enabled == true)
        {
            // ���� �ȿ� ���� ������
            if (sinkWater.waterFlow == true)
            {
                itemText.text = item.changeText; //���� �� ����
                waterInPot = true;
            }

            //���� ��ũ�� ���� �ΰ� ȭ���� ��� ���
            PotInkitchen.SetActive(true);
        }
        else
        {
            PotInkitchen.SetActive(false);
        }


        //������ interaction�� ��ġ�� ������ ���� �������� ���� �ڽ��ݶ��̴��� ���̰� �Ѵ�.  
        
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem
            && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
            }
        

        
    }



    public void interact(DisplayImage currentDisplay)
    {
       // 1. ��������Ʈ ������ off, ���Կ� ���� ���� : Ŭ���ص� �ƹ��� ���� X
       // 2. ��������Ʈ ������ off, ������ ���� Ŭ���� ����: ��������Ʈ ������ On
       // 3. ��������Ʈ ������ on, ���Կ� ���� ���� : ���Կ� ����, ������ �ٽ� off

        // ���� ����
        if(this.GetComponent<SpriteRenderer>().enabled == false) 
        { 
            if(inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
            {
               if(inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
               {
                    //�κ��丮�� �ִ� ���� ���
                    UseItem();
               }
                
            }
        }
        else //this.GetComponent<SpriteRenderer>().enabled == true
        {
            // ���� ȹ��
            ItemPickUp();
        }

    }



    // �Ⱦ� �Լ�
    public void ItemPickUp()
    {

        Inventory.Instance.AcquireItem(item);

        //Ŭ���� ������ ����
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;

        inventory.currentSelectedSlot = inventory.previousSelectedSlot;
        inventory.previousSelectedSlot = inventory.currentSelectedSlot;    
        
    }


    public void UseItem()
    {
        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); //���� ����
        this.GetComponent<SpriteRenderer>().enabled = true;
  
    } 

}
