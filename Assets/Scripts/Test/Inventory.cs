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
    private GameObject slots;  // Slot들의 부모인 Grid Setting 

    private Slot[] slot;  // 슬롯들 배열

    [SerializeField] private Item[] items;

    public Slot[] GetSlots() { return slot; }

    public GameObject currentSelectedSlot { get; set; } //현재 클릭한 슬롯
    public GameObject previousSelectedSlot { get; set; } //이전에 선택한 슬롯

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
        currentSelectedSlot = GameObject.Find("slot"); //제일 첫번째 슬롯칸으로 
        previousSelectedSlot = currentSelectedSlot;

        animator = slotBackground.GetComponent<Animator>();
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
    }


    void Update()
    {
        SelectSlot();
        CountInven();
        Check();
        HideInven(); // 2번째 슬롯도 켜졌을 경우
                     //HideDisplay(); //아이템 보이기 숨기기

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


    //슬롯 선택
    void SelectSlot()
    {
        //슬롯 정보 가져옴
        foreach (Transform slot in slots.transform)
        {

            // 아이템이 선택된 상태에서 다른 아이템을 선택시, 이전에 선택한 아이템의 chooseItem을 false로 바꿔준다
            if ((previousSelectedSlot != currentSelectedSlot) && previousSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {
                previousSelectedSlot.GetComponent<Slot>().chooseItem = false;
            }


            // 슬롯이 선택된 상태면 흰색배경으로 
            if (slot.GetComponent<Slot>().chooseItem == true)
            {
                slot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/inven2_0");
                slot.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, 1);
            }
            else //아니면 기본 색상
            {
                slot.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/invenLast");
            }

        }
    }


    //인벤토리 초기화
    void InitializeInventory()
    {

        //slots의 자식을 가져오는. slots 안에 있는 slot을 가져온다. 슬롯 정보 가져옴
        foreach (Transform slot in slots.transform)
        {
            // 슬롯 안의 item 설정
            slot.transform.GetChild(0).GetComponent<Image>().sprite
                = Resources.Load<Sprite>("Inventory Items/empty_item"); //item 이미지 초기화
            //slot.GetComponent<Slot>().ItemProperty = Slot.property.empty; //아이템 속성 empty
        }

        //currentSelectedSlot = GameObject.Find("slot"); //제일 첫번째 슬롯칸으로 
        //previousSelectedSlot = currentSelectedSlot;
    }


    public void CountInven()
    {
        second = new Transform[6];

        //6에서 12번까지의 슬롯을 담는다
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




    //아이템 획득할 때마다 
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



    //인벤로딩(저장)
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
