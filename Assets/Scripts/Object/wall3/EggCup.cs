using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggCup : MonoBehaviour, IInteractable
{
    #region PickUpItem
    private TextMeshProUGUI itemText;
    private GameObject itemNameUI;
    #endregion

    #region lockItem

    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;

    //������ ���� �� ������ �۾�
    [SerializeField]
    private string lockText = "���� ���� ����";
    #endregion

    private Inventory inventory;
    private SaveAndLoad theSaveAndLoad;

    // ��ȣ�ۿ��� ������ �̸�
    public string UnlockItem1; //egg
    public string UnlockItem2; //spoon

    public Item item;
    public Animator fadeImage;

    private GameObject egg; // �ڽ� ������Ʈ(�� ǥ��)
    public GameObject blackCube;
    public GameObject blackCube1; // �ٱ��� ť��
    public GameObject blackCubeBackground;
    public GameObject butterflyManager;
    public GameObject eggCup1; //�ٱ��� ��

    public static bool eggHere = false;
    public static float eggNum = 1;
    private float wait = 0;
    public static bool eggDrop = false;
    public static bool blackCubeHere = false;


    private void Start()
    {
        inventory = Inventory.Instance;
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
        //displayImage = GameObject.Find("displayImage").GetComponent<DisplayImage>();

        itemNameUI = GameObject.Find("ItemNameUI");
        itemText = itemNameUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        egg = this.transform.GetChild(0).gameObject;
        
    }


    private void Update()
    {
       

        //������� ť�갡 ������� 
        if (blackCube == null)
        {
            eggDrop = true; // ť�갡 ��������ٰ� ����� - ���� ȿ��
            blackCubeHere = false;
            blackCube1.SetActive(false); //wall3�� �ִ� ť�� �����ֱ�
            blackCubeBackground.SetActive(false); //ť�� ��� �����ֱ�
            
        }
        else // blackCube != null
        {
            if (blackCubeHere)
            {
                blackCube.SetActive(true); //����ť�� ����
                blackCubeBackground.SetActive(true); //ť�� ��浵 ���ֱ�
            }
            
        }

        // ���� �� ���� ������
        if(eggHere == true)
        {
            egg.SetActive(true);
            egg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
        }
        else
        {
            egg.SetActive(false);
        }


        //Ŭ�� ���
        ResetClick();


        
    }


    public void interact(DisplayImage currentDisplay)
    {
        //���� �����ִٸ�
        if(!egg.activeSelf)
        {
            // �κ��丮�� ���� �ִٸ�
            if(inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem1
                 && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {
                // �κ��丮�� �ִ� �� ���
                    UseItem();
                    eggHere = true;
      
            }

        }
        else // ���� ���� �ִٸ�
        {
            // ���� ���� ���¶��
            if(ovenPot.eggRipe)
            {

                // �������� ������ ���¶��
                if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2
                    && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    
                    // eggNum�� ���� ������Ʈ�� ��������Ʈ�� �ٲ��ش�
                    if(eggNum == 3)
                    {
                        eggNum += 1;
                        egg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        eggCup1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        theSaveAndLoad.SaveData();
                        StartCoroutine(camShake()); //ī�޶� ��鸲

                        //butterflyManager.GetComponent<ButterflyManager>().butterflyCount = 1; //���� ����
                        wait = 1f; //1�ʵ��� Ŭ�� ����
                    }
                    else if (eggNum == 4)
                    {
                        eggNum += 1;
                        egg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        eggCup1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        theSaveAndLoad.SaveData();
                        StartCoroutine(camShake()); //ī�޶� ��鸲

                        //butterflyManager.GetComponent<ButterflyManager>().butterflyCount = 4; //���� 3���� �� ����
                        wait = 1f; //1�ʵ��� Ŭ�� ����
                    }
                    else if(eggNum == 5)
                    {
                        eggNum += 1; //egg6ȭ��
                        egg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        eggCup1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        
                        StartCoroutine(camShake()); // ī�޶� ��鸲

                        blackCubeHere = true;
                        //blackCube.SetActive(true); //����ť�� ����
                        //blackCubeBackground.SetActive(true); //ť�� ��浵 ���ֱ�

                        //butterflyManager.GetComponent<ButterflyManager>().butterflyCount = 30; //���� ���⵿
                        theSaveAndLoad.SaveData();

                    }
                    else if(eggNum == 6)
                    {
                        //�ƹ��� ������ ����
                        
                    }
                    else
                    {
                        eggNum += 1;
                        // �� �Ѽ�
                        egg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        eggCup1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        theSaveAndLoad.SaveData();
                    }


                }
                else // �������� ���� �� ��
                {
                    // �� �ѽñ� �����ϸ� ���� �� ����
                    if (eggNum > 1)
                    {
                        //���� ����
                    }
                    else
                    {
                        // �� ���� 
                        eggHere = false;
                        ItemPickUp();
                        
                    }
                }

            }
            else //���� ���� �ƴ϶��
            {
                // �������� ������ ���¶��
                if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2
                    && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                    situationText.text = lockText;
                }
                else if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name != UnlockItem2
                    && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    // �������� �ƴ� �� ������ ���·� Ŭ���ϸ�
                    // �ƹ� �ϵ� �Ͼ�� �ʴ´�
                }
                else
                {
                    // �� ���� 
                    ItemPickUp();
                    eggHere = false;
                }


            }

        }
        
    }


    public void UseItem()
    {
        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); // ���Ժ��� 

        //egg.SetActive(true); //���� ������ ��������Ʈ ���ֱ�

    }


    public void ItemPickUp()
    {
        Inventory.Instance.AcquireItem(item);
        //egg.SetActive(false);
    }
    

    //1�ʵ��� ī�޶� ����
    IEnumerator camShake()
    {
        Camera.main.GetComponent<shakeBox>().enabled = true;
        fadeImage.enabled = true;

        yield return new WaitForSeconds(1f);

        Camera.main.GetComponent<shakeBox>().enabled = false;
        fadeImage.enabled = false;
    }


    //wait(�ð�)�� ���� ��ġ ����
    void ResetClick()
    {

        wait -= Time.deltaTime;

        if (wait > 0f)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(wait <= 0)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            wait = 0f;
        }

    }

}