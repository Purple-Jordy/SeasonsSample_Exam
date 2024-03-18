using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    // �κ��丮 �̱���
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

    [SerializeField] private Item[] items; // ������(�ּ�) �迭

    public Slot[] GetSlots() { return slot; } //���� ��������

    public GameObject currentSelectedSlot { get; set; } //���� Ŭ���� ����
    public GameObject previousSelectedSlot { get; set; } //������ ������ ����


    [SerializeField]
    private bool secondInven = false; //�ι�° �κ��丮

    Transform[] second; //�ι�° �κ��丮 ���Ե�

    private Animator animator;
    private SaveAndLoad theSaveAndLoad;

    public GameObject backButton;
    public GameObject slotBackground;
    public GameObject hideInven;


    void Start()
    {
        slot = slots.GetComponentsInChildren<Slot>();// ���� ĭ��
        currentSelectedSlot = GameObject.Find("slot"); // ���� ù��° ����ĭ���� 
        previousSelectedSlot = currentSelectedSlot; // ���� �ʱ�ȭ

        animator = slotBackground.GetComponent<Animator>();
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
    }


    void Update() //���� ���� ������Ʈ
    {
        SelectSlot();
        CountInven();
        Check();
        HideInven(); // 2��° ���Ե� ������ ���
                     //HideDisplay(); //������ ���̱� �����

        // �ι�° ������ ���� �ִٸ�
        if (secondInven == true)
        {
            // �ι�° ���� ���� ��� ��ư�� ���ֱ�
            backButton.SetActive(true);

        }
        else
        {
            //��ư�� ���ְ� ���� �ִϸ��̼ǵ� �ٲ��ֱ�
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
            // ���� ���� item �̹��� �ʱ�ȭ
            slot.transform.GetChild(0).GetComponent<Image>().sprite
                = Resources.Load<Sprite>("Inventory Items/empty_item"); 

        }


    }


    public void CountInven()
    {
        //�ι�° ����
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
            //�ι�° ���Կ� �������� ������ 6���� ���� ��ŭ ���ش�
            if (second[i].GetComponent<Slot>().item == null)
            {
                sum--;
            }
            else
            {
                sum++;
            }
        }

        // �ι�° ���Կ� �������� �ϳ��� ���� ���
        if (sum > 0)
        {
            //�ι�° ���� UI�� �����ش�
            secondInven = true;
        }
        else
        {
            secondInven = false;
        }


    }


    //�ι�° ���� �ִϸ��̼�
    public void ActiveInven()
    {
        //�ι�° ���� â�� �����ִٸ�
        if (animator.GetBool("InvenOpen") == false)
        {
            //�ι�° ���� â�� �����ش�
            animator.SetBool("InvenOpen", true);
        }
        else
        {
            animator.SetBool("InvenOpen", false);
        }
    }


    //�ι�° ���� â �����(����)
    void HideInven()
    {
        //���� â ���� ��ư�� Ȱ��ȭ �Ǿ��ٸ�
        if (backButton.activeSelf)
        {
            //���콺�� ���� â�� �ƴ� �ٸ� �� Ŭ���Ѵٸ� �ι�° ���� â�� �����ش�
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
            //����ִ� ĭ�� ã�Ƽ� �������� �־��ش�
            if (slot[i].item == null)
            {
               
                if(i > 5) //�ι�° ���Կ� �ִ� �������̸� �κ��丮 �ִϸ��̼� ���
                {
                    animator.SetTrigger("backButtonOn");
                }

                //������ �ְ� ������ ����
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
                slot[_arrayNum].LoadItem(items[i]);
            }
                
        }
            
    }


    // ������ üũ - ������ ����
    public void CheckItem(GameObject _item)
    {
        if(_item != null)
        {
            for (int i = 0; i < slot.Length; i++)
            {
                // ���Կ� �ִ� �������� �̸��� ���� ������Ʈ�� �������ش� (�̹� ȹ���� ������(���� ������)�̴ϱ� ������Ʈ ����)
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
