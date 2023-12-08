using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoFrame : MonoBehaviour, IInteractable
{
    //���� ������ �ִϸ��̼�
    private Animator animator;

    //���� �Ʒ� Ȯ��(�������� Ȯ�ο�)
    public bool frameDown = false;

    // ť�� Ȯ��
    private MakeCube makeCube;
    // ������ �� Ȯ��
    private fireplace fireplace;

    private GameObject photo;


    void Start()
    {
        animator = GetComponent<Animator>();

        fireplace = GameObject.Find("fireplace").GetComponent<fireplace>();
        makeCube = GameObject.Find("MakeCube").GetComponent<MakeCube>();

        photo = this.transform.GetChild(0).gameObject;
    }


    // ������Ʈ Ŭ���ϸ�
    public void interact(DisplayImage currentDisplay)
    {
        //ȭ���� zoom �����϶��� �����̴� �ִϸ��̼� ���
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            //ť��� ���� �� �� ������ ȭ���� ��� ������ �ִ� ����
            if(fireplace.IsFire == true && makeCube.cubeHere == true)
            {
                if (animator.GetBool("IsDown") == false)
                {
                    animator.SetBool("IsDown", true);
                    frameDown = true;
                }
            }
            else
            {

                if (animator.GetBool("IsDown") == false)
                {
                    animator.SetBool("IsDown", true);
                    frameDown = true;
                }
                else
                {
                    animator.SetBool("IsDown", false);
                    frameDown = false;
                }
            }


        }

    }


}
