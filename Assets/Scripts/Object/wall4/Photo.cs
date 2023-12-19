using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour, IInteractable
{


    private TextMeshProUGUI itemText;
    private GameObject itemNameUI;

    #region lockItem
    private Inventory inventory;
    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;

    //잠금해제 아이템(이 아이템이 있어야 잠금해제)
    public string UnlockItem1 = "photo1"; 
    public string UnlockItem2 = "photo3";
    public string UnlockItem3 = "photo4";

    #endregion



    // 줌 상태 확인
    private DisplayImage currentDisplay;

    // 벽난로 불 켜졌을때 사진 불도 켜지는 애니메이션
    private Animator animator;

    // 벽난로 불 확인
    //private fireplace fireplace;
    // 큐브 확인
   // private MakeCube makeCube;

    // 사진 확인
    public bool allPhoto = false;

    public SceneFader fader;

    [SerializeField]
    private string loadToScene = "3SelectSummer";

    //사진
    private GameObject photo1;
    private GameObject photo3;
    private GameObject photo4;

    private GameObject cubeComplete;
    private GameObject cubeUniverse;

    private GameObject currentObject;

    private PhotoFrame photoFrame;

    public static bool getPhoto1 = false;
    public static bool getPhoto3 = false;
    public static bool getPhoto4 = false;




    void Start()
    {
        itemNameUI = GameObject.Find("ItemNameUI");
        itemText = itemNameUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        inventory = Inventory.Instance;
        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();

        animator = GetComponent<Animator>();

        //fireplace = GameObject.Find("fireplace").GetComponent<fireplace>();
        //makeCube = GameObject.Find("MakeCube").GetComponent<MakeCube>();

        photo1 = this.transform.GetChild(0).gameObject;
        photo3 = this.transform.GetChild(1).gameObject;
        photo4 = this.transform.GetChild(2).gameObject;
        cubeComplete = this.transform.GetChild(3).gameObject;
        cubeUniverse = this.transform.GetChild(4).gameObject;

        
        photoFrame = transform.parent.GetComponent<PhotoFrame>();
    }


    private void Update()
    {
        //화면이 줌 상태가 아니거나 화면이 down 상태가 아니면(올라가 있으면) 
        if( currentDisplay.CurrentState != global::DisplayImage.State.zoom
            || this.transform.GetComponentInParent<PhotoFrame>().frameDown == false)
        {
            // 콜라이더와 애니메이션을 끈다
            this.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("photoFire", false);
            animator.SetBool("cubeHere", false);
        }
        else //화면이 줌 상태에 액자가 down 상태면
        {
            // 벽난로의 불이 켜지고 큐브도 있으면
            if (fireplace.IsFire == true && MakeCube.cubeHere == true)
            {
                // 사진의 애니메이션도 켜준다
                animator.SetBool("photoFire", true);
                // 큐브+불 애니메이션 켜주기
                animator.SetBool("cubeHere", true);
                
            }
            else if(fireplace.IsFire == true)
            {
                // 사진의 애니메이션도 켜준다
                animator.SetBool("photoFire", true);
            }

            // 말풍선 띄우기 위해 콜라이더 켜주기
            this.GetComponent<BoxCollider2D>().enabled = true;

        }

        if (getPhoto1)
        {
            photo1.SetActive(true);
        }

        if (getPhoto3)
        {
            photo3.SetActive(true);
        }

        if (getPhoto4)
        {
            photo4.SetActive(true);
        }

        //모든 사진 모았음 표시
        if (getPhoto1 && getPhoto3 && getPhoto4)
        {
            allPhoto = true;
        }


        if(currentObject != null)
        {
            if (allPhoto == true && currentDisplay.CurrentState == global::DisplayImage.State.zoom)
            {
                currentObject.SetActive(true); 
            }
            else
            {
                currentObject.SetActive(false); //화면 밖을 나가면 화면 꺼주기
            }
        }
        
        
    }


    public void interact(DisplayImage currentDisplay)
    {
        // 인벤토리에 있는 사진 확인해서 오브젝트 켜주기
        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem1
                && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
        {
            //photo1.SetActive(true);
            //효과음 플레이
            AudioManager.Instance.Play("lightOnOff");
            getPhoto1 = true;
            UseItem();
        }
        else if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2
            && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
        {
            //photo3.SetActive(true);
            //효과음 플레이
            AudioManager.Instance.Play("lightOnOff");
            getPhoto3 = true;
            UseItem();
        }
        else if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem3
            && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
        {
            //photo4.SetActive(true);
            //효과음 플레이
            AudioManager.Instance.Play("lightOnOff");
            getPhoto4 = true;
            UseItem();
        }
        else
        {
            //클릭하면 말풍선 띄우기
            if(allPhoto == false)
            {
                UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                situationText.text = "사진 미완성";
            }
            
        }

        //상태에 상관없이 클릭 애니메이션 재생
        photoFrame.GetComponent<Animator>().SetTrigger("Click");


        //만약 사진 완성 & 불 있음 & 큐브 있음 (클리어 조건 달성!)
        if (allPhoto == true && fireplace.IsFire == true && MakeCube.cubeHere == true)
        {
            // 첫번째 클릭 이벤트
            if (currentObject == null)
            {
                currentObject = cubeComplete;
                AudioManager.Instance.Play("complete");
            }
            else if(currentObject == cubeComplete) //두번째 클릭 이벤트
            {
                currentObject = cubeUniverse;
                cubeComplete.SetActive(false);

                this.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.15f);
                this.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
            }
            else if(currentObject == cubeUniverse) //세번째 클릭 이벤트 : 게임 클리어!
            {
                Debug.Log("Game Clear!");
                fader.FadeTo(loadToScene);
            }

             
        }
    }


    public void UseItem()
    {

        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); // 슬롯비우기 

    }

}
