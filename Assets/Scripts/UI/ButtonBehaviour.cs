using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonID // 버튼 열거형
    {
        roomChangeButton, 
        returnButton,
        UpButton
    }

    //enum 타입의 변수 선언 - 세 가지의 변수 중 하나 지정 가능
    public ButtonID thisButtonId;

    private DisplayImage currentDisplay;


    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    private void Update()
    {
        // 화면 상태에 따라 버튼 보이기
        HideDisplay(); //버튼 숨기기
        Display(); //버튼 보이게 하기
    }


    //버튼 숨기기
    void HideDisplay() // 1. normal: back버튼만 숨기기  2. ChangeImage, zoom: Up 버튼만 숨기기
    {
        // 1. 화면 상태가 노말이고 버튼이 returnButton일 경우
        if (currentDisplay.CurrentState == DisplayImage.State.normal && thisButtonId == ButtonID.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            //this.transform.SetSiblingIndex(0);
        }

        // 2. 화면 상태가 ChangeImage 이고, 버튼이 Up일 경우
        if ((currentDisplay.CurrentState == DisplayImage.State.ChangedView || currentDisplay.CurrentState == DisplayImage.State.zoom) 
                && thisButtonId == ButtonID.UpButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            //this.transform.SetSiblingIndex(0);
        }
    }


    //버튼 보이게 하기
    void Display() // 1. normal: back버튼 제외 다 보이기  2. ChangeImage, zoom: up 버튼 제외 다  3. ceiling : 다 보이기
    {
        // 1.현재 화면 상태가 normal이고, return 버튼일 경우
        if (currentDisplay.CurrentState == DisplayImage.State.normal && !(thisButtonId == ButtonID.returnButton))
        { 
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                     GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

        // 2. 현재 화면 상태가 ChangeImage 또는 zoom 둘 중 하나이거나 up 버튼이 아닐 경우
        if ((currentDisplay.CurrentState == DisplayImage.State.ChangedView || currentDisplay.CurrentState == DisplayImage.State.zoom)
                && !(thisButtonId == ButtonID.UpButton))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

       //3. ceiling 상태면 다 보이기
       if(currentDisplay.CurrentState == DisplayImage.State.ceiling)
       {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
       }

    }


}
