using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    // 인벤토리 싱글톤
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

    [SerializeField] private Item[] items; // 아이템(애셋) 배열

    public Slot[] GetSlots() { return slot; } //슬롯 가져오기

    public GameObject currentSelectedSlot { get; set; } //현재 클릭한 슬롯
    public GameObject previousSelectedSlot { get; set; } //이전에 선택한 슬롯


    [SerializeField]
    private bool secondInven = false; //두번째 인벤토리

    Transform[] second; //두번째 인벤토리 슬롯들

    private Animator animator;
    private SaveAndLoad theSaveAndLoad;

    public GameObject backButton;
    public GameObject slotBackground;
    public GameObject hideInven;


    void Start()
    {
        slot = slots.GetComponentsInChildren<Slot>();// 슬롯 칸들
        currentSelectedSlot = GameObject.Find("slot"); // 제일 첫번째 슬롯칸으로 
        previousSelectedSlot = currentSelectedSlot; // 슬롯 초기화

        animator = slotBackground.GetComponent<Animator>();
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
    }


    void Update() //슬롯 상태 업데이트
    {
        SelectSlot();
        CountInven();
        Check();
        HideInven(); // 2번째 슬롯도 켜졌을 경우
                     //HideDisplay(); //아이템 보이기 숨기기

        // 두번째 슬롯이 켜져 있다면
        if (secondInven == true)
        {
            // 두번째 슬롯 접고 펴는 버튼도 켜주기
            backButton.SetActive(true);

        }
        else
        {
            //버튼도 꺼주고 슬롯 애니메이션도 바꿔주기
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
            // 슬롯 안의 item 이미지 초기화
            slot.transform.GetChild(0).GetComponent<Image>().sprite
                = Resources.Load<Sprite>("Inventory Items/empty_item"); 

        }


    }


    public void CountInven()
    {
        //두번째 슬롯
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
            //두번째 슬롯에 아이템이 없으면 6에서 없는 만큼 빼준다
            if (second[i].GetComponent<Slot>().item == null)
            {
                sum--;
            }
            else
            {
                sum++;
            }
        }

        // 두번째 슬롯에 아이템이 하나라도 있을 경우
        if (sum > 0)
        {
            //두번째 슬롯 UI를 보여준다
            secondInven = true;
        }
        else
        {
            secondInven = false;
        }


    }


    //두번째 슬롯 애니메이션
    public void ActiveInven()
    {
        //두번째 슬롯 창이 닫혀있다면
        if (animator.GetBool("InvenOpen") == false)
        {
            //두번째 슬롯 창을 열어준다
            animator.SetBool("InvenOpen", true);
        }
        else
        {
            animator.SetBool("InvenOpen", false);
        }
    }


    //두번째 슬롯 창 숨기기(접기)
    void HideInven()
    {
        //슬롯 창 접는 버튼이 활성화 되었다면
        if (backButton.activeSelf)
        {
            //마우스가 슬롯 창이 아닌 다른 걸 클릭한다면 두번째 슬롯 창을 숨겨준다
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
            //비어있는 칸을 찾아서 아이템을 넣어준다
            if (slot[i].item == null)
            {
               
                if(i > 5) //두번째 슬롯에 있는 아이템이면 인벤토리 애니메이션 재생
                {
                    animator.SetTrigger("backButtonOn");
                }

                //아이템 넣고 데이터 저장
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
                slot[_arrayNum].LoadItem(items[i]);
            }
                
        }
            
    }


    // 아이템 체크 - 데이터 관련
    public void CheckItem(GameObject _item)
    {
        if(_item != null)
        {
            for (int i = 0; i < slot.Length; i++)
            {
                // 슬롯에 있는 아이템의 이름과 같은 오브젝트를 삭제해준다 (이미 획득한 아이템(저장 데이터)이니까 오브젝트 삭제)
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
