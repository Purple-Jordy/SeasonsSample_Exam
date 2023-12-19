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

    //������� ������(�� �������� �־�� �������)
    public string UnlockItem1 = "photo1"; 
    public string UnlockItem2 = "photo3";
    public string UnlockItem3 = "photo4";

    #endregion



    // �� ���� Ȯ��
    private DisplayImage currentDisplay;

    // ������ �� �������� ���� �ҵ� ������ �ִϸ��̼�
    private Animator animator;

    // ������ �� Ȯ��
    //private fireplace fireplace;
    // ť�� Ȯ��
   // private MakeCube makeCube;

    // ���� Ȯ��
    public bool allPhoto = false;

    public SceneFader fader;

    [SerializeField]
    private string loadToScene = "3SelectSummer";

    //����
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
        //ȭ���� �� ���°� �ƴϰų� ȭ���� down ���°� �ƴϸ�(�ö� ������) 
        if( currentDisplay.CurrentState != global::DisplayImage.State.zoom
            || this.transform.GetComponentInParent<PhotoFrame>().frameDown == false)
        {
            // �ݶ��̴��� �ִϸ��̼��� ����
            this.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("photoFire", false);
            animator.SetBool("cubeHere", false);
        }
        else //ȭ���� �� ���¿� ���ڰ� down ���¸�
        {
            // �������� ���� ������ ť�굵 ������
            if (fireplace.IsFire == true && MakeCube.cubeHere == true)
            {
                // ������ �ִϸ��̼ǵ� ���ش�
                animator.SetBool("photoFire", true);
                // ť��+�� �ִϸ��̼� ���ֱ�
                animator.SetBool("cubeHere", true);
                
            }
            else if(fireplace.IsFire == true)
            {
                // ������ �ִϸ��̼ǵ� ���ش�
                animator.SetBool("photoFire", true);
            }

            // ��ǳ�� ���� ���� �ݶ��̴� ���ֱ�
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

        //��� ���� ����� ǥ��
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
                currentObject.SetActive(false); //ȭ�� ���� ������ ȭ�� ���ֱ�
            }
        }
        
        
    }


    public void interact(DisplayImage currentDisplay)
    {
        // �κ��丮�� �ִ� ���� Ȯ���ؼ� ������Ʈ ���ֱ�
        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem1
                && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
        {
            //photo1.SetActive(true);
            //ȿ���� �÷���
            AudioManager.Instance.Play("lightOnOff");
            getPhoto1 = true;
            UseItem();
        }
        else if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem2
            && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
        {
            //photo3.SetActive(true);
            //ȿ���� �÷���
            AudioManager.Instance.Play("lightOnOff");
            getPhoto3 = true;
            UseItem();
        }
        else if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem3
            && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
        {
            //photo4.SetActive(true);
            //ȿ���� �÷���
            AudioManager.Instance.Play("lightOnOff");
            getPhoto4 = true;
            UseItem();
        }
        else
        {
            //Ŭ���ϸ� ��ǳ�� ����
            if(allPhoto == false)
            {
                UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                situationText.text = "���� �̿ϼ�";
            }
            
        }

        //���¿� ������� Ŭ�� �ִϸ��̼� ���
        photoFrame.GetComponent<Animator>().SetTrigger("Click");


        //���� ���� �ϼ� & �� ���� & ť�� ���� (Ŭ���� ���� �޼�!)
        if (allPhoto == true && fireplace.IsFire == true && MakeCube.cubeHere == true)
        {
            // ù��° Ŭ�� �̺�Ʈ
            if (currentObject == null)
            {
                currentObject = cubeComplete;
                AudioManager.Instance.Play("complete");
            }
            else if(currentObject == cubeComplete) //�ι�° Ŭ�� �̺�Ʈ
            {
                currentObject = cubeUniverse;
                cubeComplete.SetActive(false);

                this.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.15f);
                this.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
            }
            else if(currentObject == cubeUniverse) //����° Ŭ�� �̺�Ʈ : ���� Ŭ����!
            {
                Debug.Log("Game Clear!");
                fader.FadeTo(loadToScene);
            }

             
        }
    }


    public void UseItem()
    {

        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); // ���Ժ��� 

    }

}
