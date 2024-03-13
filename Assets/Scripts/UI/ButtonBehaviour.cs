using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonID // ��ư ������
    {
        roomChangeButton, 
        returnButton,
        UpButton
    }

    //enum Ÿ���� ���� ���� - �� ������ ���� �� �ϳ� ���� ����
    public ButtonID thisButtonId;

    private DisplayImage currentDisplay;


    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    private void Update()
    {
        // ȭ�� ���¿� ���� ��ư ���̱�
        HideDisplay(); //��ư �����
        Display(); //��ư ���̰� �ϱ�
    }


    //��ư �����
    void HideDisplay() // 1. normal: back��ư�� �����  2. ChangeImage, zoom: Up ��ư�� �����
    {
        // 1. ȭ�� ���°� �븻�̰� ��ư�� returnButton�� ���
        if (currentDisplay.CurrentState == DisplayImage.State.normal && thisButtonId == ButtonID.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            //this.transform.SetSiblingIndex(0);
        }

        // 2. ȭ�� ���°� ChangeImage �̰�, ��ư�� Up�� ���
        if ((currentDisplay.CurrentState == DisplayImage.State.ChangedView || currentDisplay.CurrentState == DisplayImage.State.zoom) 
                && thisButtonId == ButtonID.UpButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            //this.transform.SetSiblingIndex(0);
        }
    }


    //��ư ���̰� �ϱ�
    void Display() // 1. normal: back��ư ���� �� ���̱�  2. ChangeImage, zoom: up ��ư ���� ��  3. ceiling : �� ���̱�
    {
        // 1.���� ȭ�� ���°� normal�̰�, return ��ư�� ���
        if (currentDisplay.CurrentState == DisplayImage.State.normal && !(thisButtonId == ButtonID.returnButton))
        { 
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                     GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

        // 2. ���� ȭ�� ���°� ChangeImage �Ǵ� zoom �� �� �ϳ��̰ų� up ��ư�� �ƴ� ���
        if ((currentDisplay.CurrentState == DisplayImage.State.ChangedView || currentDisplay.CurrentState == DisplayImage.State.zoom)
                && !(thisButtonId == ButtonID.UpButton))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

       //3. ceiling ���¸� �� ���̱�
       if(currentDisplay.CurrentState == DisplayImage.State.ceiling)
       {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
       }

    }


}
