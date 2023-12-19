using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MakeCube : MonoBehaviour, IInteractable
{
    //�޸� ���� ���̱�
    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;

    private Inventory inventory;

    // ������ �� Ȯ��
    //private fireplace fireplace;

    // �� ���� Ȯ��
    private DisplayImage currentDisplay;

    // ť�� �ִϸ��̼�
    private Animator animator;

    // ��ȣ�ۿ��� ������ �̸�
    public string UnlockItem;

    public static bool cubeHere = false;


    void Start()
    {
        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        inventory = Inventory.Instance;

        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        //fireplace = GameObject.Find("fireplace").GetComponent<fireplace>();

        animator = GetComponent<Animator>();

    }


    private void Update()
    {
        //�� ȭ���� �ƴϸ�
        if (currentDisplay.CurrentState != DisplayImage.State.zoom) 
        {
            if (cubeHere == true)
            {
                animator.SetBool("cubeHere", true);

            }

            //�� �ִϸ��̼��� ���ֱ�
            animator.SetBool("IsFire", false);
            

        }
        else //�� ����
        {
            
            //�� ȭ���̰� ���� ������ �� �ִϸ��̼� ���
            if (fireplace.IsFire == true)
            {
                animator.SetBool("IsFire", true);
            }

            if (cubeHere == true)
            {
                animator.SetBool("cubeHere", true);

            }

            // IsFire, cubeHere �� �� true�� ��+ť�� �ִϸ��̼� ���
        }

    }


    public void interact(DisplayImage currentDisplay)
    {
        //ȭ���� zoom ������ ���� �۾� ������ 
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            //������ ������ ���� ť��� ���� ť�� ������ֱ� 
            if(inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem
                && inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {
                cubeHere = true;
                UseItem();
                AudioManager.Instance.Play("cubeInWall");
            }
            else if (cubeHere == true)
            {
                UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                situationText.text = "ť�긦 ���Ҵµ�";
            }
            else if (cubeHere == false)
            {
                UIAnimator.Play("ShowItemNameAnim", -1, 0f);
                situationText.text = "�̰� ����?";
            }
            
        }
    }


    public void UseItem()
    {

        inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); // ���Ժ��� 

    }


}
