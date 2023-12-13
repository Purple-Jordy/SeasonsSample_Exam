using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Candle : MonoBehaviour, IInteractable
{

    private Inventory inventory;
    private SaveAndLoad theSaveAndLoad;

    // �� ���� Ȯ��
    private DisplayImage currentDisplay;

    private Animator animator;
    private Animator fireAnim;

    // ��ȣ�ۿ��� ������ �̸�
    public string UnlockItem;
    public static bool candleFire = false;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        fireAnim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();

        inventory = Inventory.Instance;
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    private void Update()
    {
        // ���� ���� : �кҿ� ���� �ٿ���
        if (candleFire)
        {
            fireAnim.enabled = true;
        }

        //�� ȭ���϶��� �ݶ��̴��� ���ش�
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        else // ���� �ƴϸ� ���ش�
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }


    public void interact(DisplayImage currentDisplay)
    {

        //ȭ���� zoom �����϶��� �����̰�
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            //���� ���� �ִϸ��̼�
            animator.SetTrigger("click");

            // ������ ������
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
            {
                if (inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
                {
                    // �� �ִϸ��̼� ���
                    //fireAnim.enabled = true;
                    candleFire = true;
                    theSaveAndLoad.SaveData();
                }

            }
        }
    }


}



