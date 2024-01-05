 using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ovenPot : MonoBehaviour, IInteractable
{
    #region PickUpItem
 

    private GameObject InventorySlots;
    private TextMeshProUGUI itemText;
    private GameObject itemNameUI;
    #endregion


    #region lockItem
    public string UnlockItem1; //������� ������(�� �������� �־�� �������)
    public string UnlockItem2;
    public string UnlockItem3;

    private Inventory inventory;

    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;
    #endregion

    private DisplayImage displayImage;
    private SaveAndLoad theSaveAndLoad;

    //private kitchenPot KitchenPot; // ��ũ�뿡 ���� �� ����
    private Animator valveAnim; // ��� ���� Ȯ�� ����
    public GameObject PotOnOven; // wall3 ���¿��� ���̴� ����
    public GameObject whiteSmoke; // �� ����
    public GameObject blackSmoke; // ���� ����


    public static bool eggHere = false; // ���� ���� �� �ִ��� ����
    public static bool potHere = false; // ���� ���������� ���� �ִ���
    public bool boilPot = false; // ���� ���� �ִ��� 
    public static bool eggRipe = false; // ���� �;�����

    public Item item1; 
    public Item item2;


    private void Start()
    {
        //����� ���������� �������� �����ִ� ���¿��� �Ѵ�
        
        itemText = GameObject.Find("displayText").GetComponent<TextMeshProUGUI>();
        itemNameUI = GameObject.Find("ItemNameUI");
        inventory = Inventory.Instance;

        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        displayImage = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();

        //KitchenPot = GameObject.Find("kitchenPot").GetComponent<kitchenPot>();
        valveAnim = GameObject.Find("GrayValve").transform.GetChild(0).GetComponent<Animator>();

        //this.GetComponent<SpriteRenderer>().enabled = potHere;
    }


    private void OnEnable()
    {
        boilPot = false;
    }


    private void Update()
    {
        //�׷��� ��갡 �� ���� ������
        if (valveAnim.GetBool("ValveTurnOn") == false) 
        {
            // ������ �ִϸ��̼��� ������
            this.transform.GetChild(0).GetComponent<Animator>().SetBool("hasGas", false);
        }


        //���� ���������� ���� ����
        if (potHere == true)
        {


            
            // ���� ��갡 ���� ������
            if (valveAnim.GetBool("ValveTurnOn") == true)
            {
                // �� �ִϸ��̼��� ������ ���¶��
                if(this.transform.GetChild(0).GetComponent<Animator>().GetBool("hasGas") == true)
                {
                    // ���� �ִٸ� ���´�
                    if (kitchenPot.waterInPot == true)
                    {
                        boilPot = true;
                    }
                }
                
                
            }


            //���� ���������� ���� �ΰ� ȭ���� ��� ���
            //PotOnOven.SetActive(true);
            this.GetComponent<SpriteRenderer>().enabled = true; // ���� �̹��� ����

            // �� ���� ���¿� ���� ������ 
            if (boilPot == true && eggHere == true)
             {
                //���� ���� ����
                blackSmoke.SetActive(true);
 
             }
             else if(boilPot == true && eggHere == false)
            {
                //�Ͼ� ���⸸ ����
                whiteSmoke.SetActive(true);
                blackSmoke.SetActive(false);
            }
            else
            {
                whiteSmoke.SetActive(false);
                blackSmoke.SetActive(false);
            }
        }
        else // ���� ���������� ���� ������ ȭ�� �ٱ��� ���� ���ش�
        {
            
            
            
            //PotOnOven.SetActive(false); 
            this.GetComponent<SpriteRenderer>().enabled = false; // ���� �̹��� ����
        }

    }


    public void interact(DisplayImage currentDisplay)
    {
        // 1. ��������Ʈ ������ off, ���Կ� ���� ���� : Ŭ���ص� �ƹ��� ���� X
        // 2. ��������Ʈ ������ off, ������ ���� Ŭ���� ����: ��������Ʈ ������ On(���� ����)
        // 3. ��������Ʈ ������ on(���� ����), ���Կ� ���� ���� : ���Կ� ����, ������ �ٽ� off(���� �����)
        // 4. ������ ��������Ʈ(����)�� �ִ� ���� �۵��ؾ� �Ѵ�. 
        // 5. ���� ������ ���·� ������ ������ ����� ������ �־�� �Ѵ�.  
        // 6. ���� ������ ���� + �ȿ� ���� ������ ������ ������ �ƹ��͵� ȹ���ϸ� �ȵȴ�.


        // 1. ���������� ���� ���� ���ٸ�
        if (this.GetComponent<SpriteRenderer>().enabled == false)
        {
            // ������ ������ ������
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem1
                && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {
                //�κ��丮�� �ִ� ���� ���
                UseItem(); // ���� �÷���
                potHere = true;


            } // ������ ������ �����̶��
            else if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2
                    && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {

                // ���� ��갡 ���� ������
                if (valveAnim.GetBool("ValveTurnOn") == true)
                {
                    //�̹� ���� ���� ���� ���°� �ƴ϶��
                    if (this.transform.GetChild(0).GetComponent<Animator>().GetBool("hasGas") != true)
                    {
                        // ���� ���� Ų��
                        this.transform.GetChild(0).GetComponent<Animator>().SetBool("hasGas", true);
                        //ȿ���� �÷���
                        AudioManager.Instance.Play("ovenFire");
                    }

                    
                }
                else //������ ������ ������ �������� ���� ���¸� "���� ����" �߱�
                {
                    UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                    situationText.text = "���� ����";
                }


            }
            
        }
        else // 1. ���� ���������� ���� �ִٸ� //this.GetComponent<SpriteRenderer>().enabled == true 
        {
            // 2.������ ���������� (���� & �� ������ ������� ���� ������)
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2
                && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {

                // ���� ��갡 ���� ������
                if (valveAnim.GetBool("ValveTurnOn") == true)
                {
                    //�̹� ���� ���� ���� ���°� �ƴ϶��
                    if (this.transform.GetChild(0).GetComponent<Animator>().GetBool("hasGas") != true)
                    {
                        // ���� ���� Ų��
                        this.transform.GetChild(0).GetComponent<Animator>().SetBool("hasGas", true);
                        //ȿ���� �÷���
                        AudioManager.Instance.Play("ovenFire");
                    }
                }
                else //������ ������ ������ �������� ���� ���¸� "���� ����" �߱�
                {
                    UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                    situationText.text = "���� ����";
                }


            }
            else // 2.������ ������ �� �ƴϸ� - ���� �ȿ� �� ����
            {
                // 3.���� ���� �ִµ�
                if (eggHere)
                {
                    // ���� ���� ���� �ְ� ���� �ȿ� ���� �ִٸ�
                    if (this.transform.GetChild(0).GetComponent<Animator>().GetBool("hasGas") == true
                        && kitchenPot.waterInPot == true)
                    {
                        //���� �� ȹ��
                        eggRipe = true;
                        // �� ���� �ִϸ��̼� �߰�

                        //itemText.text = item2.changeText; // ���� ��
                        
                        eggHere = false;
                        ItemPickUp(item2);
                    }
                    else
                    {
                        // ���� ���� �� ȹ��
                        //itemText.text = item2.itemText; // ���� ���� ��
                        
                        eggHere = false;
                        ItemPickUp(item2);
                    }

                }
                else // 3.���� �ȿ� ���� ���ٸ�
                {

                    // �� ������ �����ߴٸ�(���Կ� ���� ������)
                    if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem3
                        && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                    {

                        // ����� �ִ� ���� ����
                        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot();
                        AudioManager.Instance.Play("chooseItem");
                        eggHere = true;
                        Debug.Log("egg in the pot");


                    }
                    else // ���� ȹ�� ����
                    {

                        // ���� ������ ���¶��
                        if (boilPot == true)
                        {
                            //�߰ſ�! ��ǳ�� ������ ȹ������ ���ϰ�
                            UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                            situationText.text = "�߰ſ�!";
                            
                        }
                        else //���� �� ������ ���¶��
                        {
                            /*if (KitchenPot.waterInPot == true)
                            {
                                itemText.text = item1.changeText; //���� �� ����
                            }
                            else
                            {
                                itemText.text = item1.itemText; //�� ����
                            }*/

                                
                                //���� ���ֱ�
                                //this.GetComponent<SpriteRenderer>().enabled = false;
                                potHere = false;

                            // ���� ȹ��
                            ItemPickUp(item1);
                        }
                            
                        
                    }

                }
            }

        }
        
        
    }



    // �Ⱦ� �Լ�(������ ȹ��)
    public void ItemPickUp(Item _item)
    {
        Inventory.Instance.AcquireItem(_item);
        
    }

    // ������ ���
    public void UseItem()
    {
        /*if (KitchenPot.waterInPot == true )
        {
            itemText.text = item1.changeText; //���� �� ����

        }*/

        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); //���� ����

        //this.GetComponent<SpriteRenderer>().enabled = true; // ���� �̹��� ����

        
    }

}
