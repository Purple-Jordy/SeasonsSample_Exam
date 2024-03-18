using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Ceiling : MonoBehaviour, IInteractable // �������̽� ���
{

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        // �ڽ�(�Ⱦ��� ������)�� �ִٸ� 
        if (this.transform.childCount != 0)
        {
            // ������ on ������ ���� ���̰�
            if (LightSwitch.lightOn == true) 
            {
                //�ڽ��� ������Ʈ ���ֱ�
                this.transform.GetChild(0).gameObject.SetActive(true);

                // �ҷ����� ���� : ������ ���� ���¸� ������Ʈ �ı��ϱ�
                if (Photo.getPhoto1)
                {
                    Destroy(this.transform.GetChild(0).gameObject);
                }
            }
            
        }
        
    }


    // �������̽� ���
    //Ŭ�� �̺�Ʈ : 1. Ŭ�� �� ������ �ִϸ��̼� ��� 2. �ڽ�(������) ȹ��
    public void interact(DisplayImage currentDisplay)
    {
        //Ŭ���� ������ õ�� ���� �ִϸ��̼� ���
        animator.SetTrigger("IsClick");

        // �ڽ�(�Ⱦ��� ������)�� �ִٸ� 
        if (this.transform.childCount != 0)
        {
            //�ڽ��� active ���¶�� ������ ȹ��
            if (this.transform.GetChild(0).gameObject.activeSelf)
            {
                this.transform.GetChild(0).GetComponent<ItemPickUp>().CanPickUp();
            }

        }
    }


}
