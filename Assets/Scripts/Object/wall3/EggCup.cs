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

    //아이템 없을 시 나오는 글씨
    [SerializeField]
    private string lockText = "아직 익지 않음";
    #endregion

    private Inventory inventory;
    private SaveAndLoad theSaveAndLoad;

    // 상호작용할 아이템 이름
    public string UnlockItem1; //egg
    public string UnlockItem2; //spoon

    public Item item;
    public Animator fadeImage;

    private GameObject egg; // 자식 오브젝트(알 표시)
    public GameObject blackCube;
    public GameObject blackCube1; // 바깥의 큐브
    public GameObject blackCubeBackground;
    public GameObject butterflyManager;
    public GameObject eggCup1; //바깥의 알

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
       

        //만들어진 큐브가 사라지면 
        if (blackCube == null)
        {
            eggDrop = true; // 큐브가 만들어졌다가 사라짐 - 나비 효과
            blackCubeHere = false;
            blackCube1.SetActive(false); //wall3에 있는 큐브 없애주기
            blackCubeBackground.SetActive(false); //큐브 배경 없애주기
            
        }
        else // blackCube != null
        {
            if (blackCubeHere)
            {
                blackCube.SetActive(true); //블랙큐브 등장
                blackCubeBackground.SetActive(true); //큐브 배경도 켜주기
            }
            
        }

        // 알이 컵 위에 있으면
        if(eggHere == true)
        {
            egg.SetActive(true);
            egg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
        }
        else
        {
            egg.SetActive(false);
        }


        //클릭 허용
        ResetClick();


        
    }


    public void interact(DisplayImage currentDisplay)
    {
        //알이 꺼져있다면
        if(!egg.activeSelf)
        {
            // 인벤토리에 알이 있다면
            if(inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem1
                 && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {
                // 인벤토리에 있는 알 사용
                    UseItem();
                    eggHere = true;
      
            }

        }
        else // 알이 켜져 있다면
        {
            // 알이 익은 상태라면
            if(ovenPot.eggRipe)
            {

                // 숟가락을 선택한 상태라면
                if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2
                    && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    
                    // eggNum에 따라서 오브젝트를 스프라이트를 바꿔준다
                    if(eggNum == 3)
                    {
                        eggNum += 1;
                        egg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        eggCup1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        theSaveAndLoad.SaveData();
                        StartCoroutine(camShake()); //카메라 흔들림

                        //butterflyManager.GetComponent<ButterflyManager>().butterflyCount = 1; //나비 생성
                        wait = 1f; //1초동안 클릭 제한
                    }
                    else if (eggNum == 4)
                    {
                        eggNum += 1;
                        egg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        eggCup1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        theSaveAndLoad.SaveData();
                        StartCoroutine(camShake()); //카메라 흔들림

                        //butterflyManager.GetComponent<ButterflyManager>().butterflyCount = 4; //나비 3마리 더 등장
                        wait = 1f; //1초동안 클릭 제한
                    }
                    else if(eggNum == 5)
                    {
                        eggNum += 1; //egg6화면
                        egg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        eggCup1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        
                        StartCoroutine(camShake()); // 카메라 흔들림

                        blackCubeHere = true;
                        //blackCube.SetActive(true); //블랙큐브 등장
                        //blackCubeBackground.SetActive(true); //큐브 배경도 켜주기

                        //butterflyManager.GetComponent<ButterflyManager>().butterflyCount = 30; //나비 총출동
                        theSaveAndLoad.SaveData();

                    }
                    else if(eggNum == 6)
                    {
                        //아무런 반응이 없다
                        
                    }
                    else
                    {
                        eggNum += 1;
                        // 알 뿌셔
                        egg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        eggCup1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (eggNum));
                        theSaveAndLoad.SaveData();
                    }


                }
                else // 숟가락을 선택 안 함
                {
                    // 알 뿌시기 시작하면 집을 수 없음
                    if (eggNum > 1)
                    {
                        //반응 없음
                    }
                    else
                    {
                        // 알 집기 
                        eggHere = false;
                        ItemPickUp();
                        
                    }
                }

            }
            else //익은 알이 아니라면
            {
                // 숟가락을 선택한 상태라면
                if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2
                    && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                    situationText.text = lockText;
                }
                else if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name != UnlockItem2
                    && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    // 숟가락이 아닌 걸 선택한 상태로 클릭하면
                    // 아무 일도 일어나지 않는다
                }
                else
                {
                    // 알 집기 
                    ItemPickUp();
                    eggHere = false;
                }


            }

        }
        
    }


    public void UseItem()
    {
        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); // 슬롯비우기 

        //egg.SetActive(true); //알이 있으니 스프라이트 켜주기

    }


    public void ItemPickUp()
    {
        Inventory.Instance.AcquireItem(item);
        //egg.SetActive(false);
    }
    

    //1초동안 카메라 흔들기
    IEnumerator camShake()
    {
        Camera.main.GetComponent<shakeBox>().enabled = true;
        fadeImage.enabled = true;

        yield return new WaitForSeconds(1f);

        Camera.main.GetComponent<shakeBox>().enabled = false;
        fadeImage.enabled = false;
    }


    //wait(시간)에 따른 터치 막기
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
