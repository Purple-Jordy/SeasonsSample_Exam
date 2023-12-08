using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour, IInteractable
{

    private SpriteRenderer render;
    private BoxCollider2D windowView;

    private bool curtainOpen = false;

    public GameObject outsideLaura;
    public GameObject outsideShadow;



    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        windowView = GameObject.Find("windowView").GetComponent<BoxCollider2D>();
    }


    private void OnEnable()
    {
        if (render.sprite.name == "window2")
        {
            RandomAppear();
        }
    }



    public void interact(DisplayImage currentDisplay)
    {
        
        if(render.sprite.name == "window0")
        {
            render.sprite = Resources.Load<Sprite>("Object/window1");
        }
        else if(render.sprite.name == "window1" && curtainOpen == false)
        {
            render.sprite = Resources.Load<Sprite>("Object/window2"); //열림 상태
            curtainOpen = true;
            windowView.enabled = true;
        }
        else if (render.sprite.name == "window1" && curtainOpen == true)
        {
            render.sprite = Resources.Load<Sprite>("Object/window0"); // 닫힘 상태
            windowView.enabled = false;
            curtainOpen = false;
        }
        else if (render.sprite.name == "window2")
        {
            render.sprite = Resources.Load<Sprite>("Object/window1");
            windowView.enabled = false;
        }

    }


    void RandomAppear()
    {
        //45% : null, 35%: 로라, 20% 그림자
        Choose(new float[3] { 20f, 35f, 45f });

        float Choose(float[] probs)
        {

            float total = 0;

            // 각각 요소를 더해준다 (100f)
            foreach (float elem in probs)
            {
                total += elem;
            }

            //랜덤포인트는 Random.value * 모든 플로트의 합계
            //Random.value : 0.0에서 1.0 사이의 임의의 부동 소수점 수를 제공합니다. 
            //일반적인 사용법은 해당 결과를 곱하여 0과 선택한 범위 사이의 숫자로 변환하는 것입니다.
            float randomPoint = Random.value * total;

            for (int i = 0; i < probs.Length; i++)
            {
                //랜덤포인트가 요소보다 작은 경우
                if (randomPoint < probs[i])
                {
                    switch (i)
                    {
                        case 0: //20f 안에 랜덤포인트가 생성된 경우
                            outsideShadow.SetActive(true);
                            outsideLaura.SetActive(false);
                            break;
                        case 1: //21f~50f 안에 생성된 경우
                            outsideShadow.SetActive(false);
                            outsideLaura.SetActive(true);
                            break;
                        case 2: //51f~100f 안에 생성된 경우
                            outsideShadow.SetActive(false);
                            outsideLaura.SetActive(false);
                            break;

                    }

                    return i;
                }
                else //랜덤포인트가 요소보다 큰 경우
                {
                    //랜덤포인트가 30이면 probs[0]=20f, 30-20=10; 그래서 case:1로 들어가게 된다
                    randomPoint -= probs[i];
                }
            }
            return probs.Length - 1;
        }
    }


}
