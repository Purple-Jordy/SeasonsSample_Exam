using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        //DontDestroyOnLoad(gameObject);
    }
    #endregion




    [SerializeField]
    private GameObject slots;  // Slot���� �θ��� Grid Setting 

    private Slot[] slot;  // ���Ե� �迭

    [SerializeField] private Item[] items;

    public Slot[] GetSlots() { return slot; }

    public GameObject currentSelectedSlot { get; set; } //���� Ŭ���� ����
    public GameObject previousSelectedSlot { get; set; } //������ ������ ����

    public bool checkItem = false;

    [SerializeField]
    private bool secondInven = false;

    Transform[] second;

    private Animator animator;
    private SaveAndLoad theSaveAndLoad;

    public GameObject backButton;
    public GameObject slotBackground;
    public GameObject hideInven;


    void Start()
    {
        slot = slots.GetComponentsInChildren<Slot>();
        //InitializeInventory();
        currentSelectedSlot = GameObject.Find("slot"); //���� ù��° ����ĭ���� 
        previousSelectedSlot = currentSelectedSlot;

        animator = slotBackground.GetComponent<Animator>();
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
    }


    void Update()
    {
        SelectSlot();
        CountInven();
        Check();
        HideInven(); // 2��° ���Ե� ������ ���
                     //HideDisplay(); //������ ���̱� �����

        if (secondInven == true)
        {
            backButton.SetActive(true);

        }
        else
        {
            backButton.SetActive(false);
            animator.SetBool("InvenOpen", false);
        }
    }


    //���� ����
    void SelectSlot()
    {
        //���� ���� ������
        foreach (Transform slot in slots.transform)
        {

            // �������� ���õ� ���¿��� �ٸ� �������� ���ý�, ������ ������ �������� chooseItem�� false�� �ٲ��ش�
            if ((previousSelectedSlot != currentSelectedSlot) && previousSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {
                previousSelectedSlot.GetComponent<Slot>().chooseItem = false;
            }


            // ������ ���õ� ���¸� ���������� 
            if (slot.GetComponent<Slot>().chooseItem == true)
            {
                slot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/inven2_0");
                slot.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, 1);
            }
            else //�ƴϸ� �⺻ ����
            {
                slot.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/invenLast");
            }

        }
    }


    //�κ��丮 �ʱ�ȭ
    void InitializeInventory()
    {

        //slots�� �ڽ��� ��������. slots �ȿ� �ִ� slot�� �����´�. ���� ���� ������
        foreach (Transform slot in slots.transform)
        {
            // ���� ���� item ����
            slot.transform.GetChild(0).GetComponent<Image>().sprite
                = Resources.Load<Sprite>("Inventory Items/empty_item"); //item �̹��� �ʱ�ȭ
            //slot.GetComponent<Slot>().ItemProperty = Slot.property.empty; //������ �Ӽ� empty
        }

        //currentSelectedSlot = GameObject.Find("slot"); //���� ù��° ����ĭ���� 
        //previousSelectedSlot = currentSelectedSlot;
    }


    public void CountInven()
    {
        second = new Transform[6];

        //6���� 12�������� ������ ��´�
        for (int i = 6; i < 12; i++)
        {
            second[i - 6] = slots.transform.GetChild(i).transform;
        }

    }


    void Check()
    {
        int sum = 6;

        for (int i = 0; i < second.Length; i++)
        {
            if (second[i].GetComponent<Slot>().item == null)
            {
                sum--;
            }
            else
            {
                sum++;
            }
        }

        if (sum > 0)
        {
            secondInven = true;
        }
        else
        {
            secondInven = false;
        }


    }

    public void ActiveInven()
    {
        if (animator.GetBool("InvenOpen") == false)
        {
            animator.SetBool("InvenOpen", true);
        }
        else
        {
            animator.SetBool("InvenOpen", false);
        }
    }



    void HideInven()
    {
        if (backButton.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                animator.SetBool("InvenOpen", false);
            }
        }
    }




    //������ ȹ���� ������ 
    public void AcquireItem(Item _item)
    {
        
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].item == null)
            {
                slot[i].AddItem(_item);
                theSaveAndLoad.SaveData();
                return;
            }
        }

        
    }



    //�κ��ε�(����)
    public void LoadToInven(int _arrayNum, string _itemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].itemName == _itemName)
            {
                slot[_arrayNum].AddItem(items[i]);
            }
                
        }
            
    }



    public void CheckItem(GameObject _item)
    {
        if(_item != null)
        {
            for (int i = 0; i < slot.Length; i++)
            {

                if (slot[i].item != null && slot[i].item.itemName == _item.GetComponent<ItemPickUp>().item.itemName)
                {
                    Destroy(_item);
                    Debug.Log($"Destroy Item : {_item}");
                    return;
                }

            }
        }
        
    }


}
