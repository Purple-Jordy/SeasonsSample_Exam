using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Phone : MonoBehaviour, IInteractable
{
    //phone �ִϸ��̼�
    private Animator animator;

    // situation(��ǳ��) �ִϸ��̼�
    private GameObject situationUI;
    private TextMeshProUGUI situationText;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        // ��ǳ��UI�� ��������
        situationUI = GameObject.Find("situationUI");
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }


    private void OnEnable()
    {
        animator.Rebind();
    }


    // Ŭ�� �̺�Ʈ
    public void interact(DisplayImage currentDisplay)
    {
        //Ŭ�� ���� �� ���� �� ��� ������ �ִϸ��̼ǵ� ���
        if (animator.GetBool("PutOnPhone") == false)
        {
            //�� �ִϸ��̼�
            animator.SetBool("PutOnPhone", true);

            //��ǳ�� �ִϸ��̼�
            situationUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);
            situationText.text = "�ʰ� ������ ��� �͵��� ����.";

        }
        else if (animator.GetBool("PutOnPhone") == true) 
        {
            //���� ��� ������ �� �������� �ִϸ��̼� ���
            animator.SetBool("PutOnPhone", false);
        }

    }
}
