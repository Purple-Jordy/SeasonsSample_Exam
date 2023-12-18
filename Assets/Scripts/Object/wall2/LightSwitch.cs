using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour, IInteractable
{
    public SceneFader fader;

    // 조명이 켜져 있는지 확인
    public static bool lightOn = false;


    private void Start()
    {
        // 초기화(조명 off 상태)
        lightOn = false;


    }


    //클릭시 일어나는 일 - 조명 on off
    public void interact(DisplayImage currentDisplay)
    {
        if(lightOn) //불이 켜져 있는 상태면
        {
            fader.LightOff(); //페이더로 어둡게

            // 스위치 off 이미지로 교체
            this.gameObject.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/lightSwitchOff"); 
            
            //lightOn false로 바꿔주기
            lightOn = false;
        }
        else //조명이 꺼져 있으면
        {
            fader.LightOn(); // 페이더로 밝게

            // 스위치 on 이미지로 교체
            this.gameObject.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/lightSwitchOn");

            //lightOn true로 바꿔주기
            lightOn = true;
        }

        //효과음 플레이
        AudioManager.Instance.Play("lightOnOff");
    }

    
}
