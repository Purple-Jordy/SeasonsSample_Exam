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
    public string UnlockItem1; //잠금해제 아이템(이 아이템이 있어야 잠금해제)
    public string UnlockItem2;
    public string UnlockItem3;

    private Inventory inventory;

    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;
    #endregion

    private DisplayImage displayImage;
    private SaveAndLoad theSaveAndLoad;

    //private kitchenPot KitchenPot; // 싱크대에 있을 때 냄비
    private Animator valveAnim; // 밸브 켜짐 확인 유무
    public GameObject PotOnOven; // wall3 상태에서 보이는 냄비
    public GameObject whiteSmoke; // 흰 연기
    public GameObject blackSmoke; // 검정 연기


    public static bool eggHere = false; // 알이 냄비에 들어가 있는지 유무
    public static bool potHere = false; // 냄비가 가스레인지 위에 있는지
    public bool boilPot = false; // 냄비가 끓고 있는지 
    public static bool eggRipe = false; // 알이 익었는지

    public Item item1; 
    public Item item2;


    private void Start()
    {
        //냄비는 스프라이터 렌더러가 꺼져있는 상태여야 한다
        
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
        //그레이 밸브가 안 켜져 있으면
        if (valveAnim.GetBool("ValveTurnOn") == false) 
        {
            // 가스불 애니메이션은 꺼진다
            this.transform.GetChild(0).GetComponent<Animator>().SetBool("hasGas", false);
        }


        //냄비가 가스레인지 위에 있음
        if (potHere == true)
        {


            
            // 가스 밸브가 켜져 있으면
            if (valveAnim.GetBool("ValveTurnOn") == true)
            {
                // 불 애니메이션이 나오는 상태라면
                if(this.transform.GetChild(0).GetComponent<Animator>().GetBool("hasGas") == true)
                {
                    // 물이 있다면 끓는다
                    if (kitchenPot.waterInPot == true)
                    {
                        boilPot = true;
                    }
                }
                
                
            }


            //냄비를 가스레인지 위에 두고 화면을 벗어날 경우
            //PotOnOven.SetActive(true);
            this.GetComponent<SpriteRenderer>().enabled = true; // 냄비 이미지 띄우기

            // 물 끓는 상태에 알이 있으면 
            if (boilPot == true && eggHere == true)
             {
                //검정 연기 나옴
                blackSmoke.SetActive(true);
 
             }
             else if(boilPot == true && eggHere == false)
            {
                //하얀 연기만 나옴
                whiteSmoke.SetActive(true);
                blackSmoke.SetActive(false);
            }
            else
            {
                whiteSmoke.SetActive(false);
                blackSmoke.SetActive(false);
            }
        }
        else // 냄비가 가스레인지 위에 없으면 화면 바깥의 냄비도 꺼준다
        {
            
            
            
            //PotOnOven.SetActive(false); 
            this.GetComponent<SpriteRenderer>().enabled = false; // 냄비 이미지 띄우기
        }

    }


    public void interact(DisplayImage currentDisplay)
    {
        // 1. 스프라이트 렌더러 off, 슬롯에 없는 상태 : 클릭해도 아무런 반응 X
        // 2. 스프라이트 렌더러 off, 슬롯의 냄비가 클릭된 상태: 스프라이트 렌더러 On(냄비 생성)
        // 3. 스프라이트 렌더러 on(냄비 생성), 슬롯에 없는 상태 : 슬롯에 생성, 렌더러 다시 off(냄비 사라짐)
        // 4. 성냥은 스프라이트(냄비)가 있던 없던 작동해야 한다. 
        // 5. 냄비가 생성된 상태로 성냥을 눌러도 냄비는 가만히 있어야 한다.  
        // 6. 냄비가 생성된 상태 + 안에 알이 있으면 성냥을 눌러도 아무것도 획득하면 안된다.


        // 1. 가스레인지 위에 냄비가 없다면
        if (this.GetComponent<SpriteRenderer>().enabled == false)
        {
            // 선택한 슬롯이 냄비라면
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem1
                && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {
                //인벤토리에 있는 냄비 사용
                UseItem(); // 냄비 올려둠
                potHere = true;


            } // 선택한 슬롯이 성냥이라면
            else if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2
                    && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {

                // 가스 밸브가 켜져 있으면
                if (valveAnim.GetBool("ValveTurnOn") == true)
                {
                    //이미 가스 불이 켜진 상태가 아니라면
                    if (this.transform.GetChild(0).GetComponent<Animator>().GetBool("hasGas") != true)
                    {
                        // 가스 불을 킨다
                        this.transform.GetChild(0).GetComponent<Animator>().SetBool("hasGas", true);
                        //효과음 플레이
                        AudioManager.Instance.Play("ovenFire");
                    }

                    
                }
                else //성냥이 있지만 가스가 켜져있지 않은 상태면 "연료 없음" 뜨기
                {
                    UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                    situationText.text = "연료 없음";
                }


            }
            
        }
        else // 1. 냄비가 가스레인지 위에 있다면 //this.GetComponent<SpriteRenderer>().enabled == true 
        {
            // 2.성냥을 선택했으면 (냄비 & 알 유무와 상관없이 불이 켜진다)
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2
                && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {

                // 가스 밸브가 켜져 있으면
                if (valveAnim.GetBool("ValveTurnOn") == true)
                {
                    //이미 가스 불이 켜진 상태가 아니라면
                    if (this.transform.GetChild(0).GetComponent<Animator>().GetBool("hasGas") != true)
                    {
                        // 가스 불을 킨다
                        this.transform.GetChild(0).GetComponent<Animator>().SetBool("hasGas", true);
                        //효과음 플레이
                        AudioManager.Instance.Play("ovenFire");
                    }
                }
                else //성냥이 있지만 가스가 켜져있지 않은 상태면 "연료 없음" 뜨기
                {
                    UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                    situationText.text = "연료 없음";
                }


            }
            else // 2.성냥을 선택한 게 아니면 - 냄비 안에 알 유무
            {
                // 3.알이 냄비에 있는데
                if (eggHere)
                {
                    // 가스 불이 켜져 있고 냄비 안에 물이 있다면
                    if (this.transform.GetChild(0).GetComponent<Animator>().GetBool("hasGas") == true
                        && kitchenPot.waterInPot == true)
                    {
                        //익은 알 획득
                        eggRipe = true;
                        // 물 끓는 애니메이션 추가

                        //itemText.text = item2.changeText; // 익은 알
                        
                        eggHere = false;
                        ItemPickUp(item2);
                    }
                    else
                    {
                        // 익지 않은 알 획득
                        //itemText.text = item2.itemText; // 익지 않은 알
                        
                        eggHere = false;
                        ItemPickUp(item2);
                    }

                }
                else // 3.냄비 안에 알이 없다면
                {

                    // 알 슬롯을 선택했다면(슬롯에 알이 있으면)
                    if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem3
                        && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                    {

                        // 계란이 있는 슬롯 비우기
                        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot();
                        AudioManager.Instance.Play("chooseItem");
                        eggHere = true;
                        Debug.Log("egg in the pot");


                    }
                    else // 냄비 획득 관련
                    {

                        // 냄비가 데워진 상태라면
                        if (boilPot == true)
                        {
                            //뜨거워! 말풍선 나오고 획득하지 못하게
                            UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                            situationText.text = "뜨거워!";
                            
                        }
                        else //냄비가 안 데워진 상태라면
                        {
                            /*if (KitchenPot.waterInPot == true)
                            {
                                itemText.text = item1.changeText; //물이 든 냄비
                            }
                            else
                            {
                                itemText.text = item1.itemText; //빈 냄비
                            }*/

                                
                                //냄비 없애기
                                //this.GetComponent<SpriteRenderer>().enabled = false;
                                potHere = false;

                            // 냄비 획득
                            ItemPickUp(item1);
                        }
                            
                        
                    }

                }
            }

        }
        
        
    }



    // 픽업 함수(아이템 획득)
    public void ItemPickUp(Item _item)
    {
        Inventory.Instance.AcquireItem(_item);
        
    }

    // 아이템 사용
    public void UseItem()
    {
        /*if (KitchenPot.waterInPot == true )
        {
            itemText.text = item1.changeText; //물이 든 냄비

        }*/

        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); //슬롯 비우기

        //this.GetComponent<SpriteRenderer>().enabled = true; // 냄비 이미지 띄우기

        
    }

}
