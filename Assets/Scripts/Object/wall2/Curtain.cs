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
            render.sprite = Resources.Load<Sprite>("Object/window2"); //���� ����
            curtainOpen = true;
            windowView.enabled = true;
        }
        else if (render.sprite.name == "window1" && curtainOpen == true)
        {
            render.sprite = Resources.Load<Sprite>("Object/window0"); // ���� ����
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
        //45% : null, 35%: �ζ�, 20% �׸���
        Choose(new float[3] { 20f, 35f, 45f });

        float Choose(float[] probs)
        {

            float total = 0;

            // ���� ��Ҹ� �����ش� (100f)
            foreach (float elem in probs)
            {
                total += elem;
            }

            //��������Ʈ�� Random.value * ��� �÷�Ʈ�� �հ�
            //Random.value : 0.0���� 1.0 ������ ������ �ε� �Ҽ��� ���� �����մϴ�. 
            //�Ϲ����� ������ �ش� ����� ���Ͽ� 0�� ������ ���� ������ ���ڷ� ��ȯ�ϴ� ���Դϴ�.
            float randomPoint = Random.value * total;

            for (int i = 0; i < probs.Length; i++)
            {
                //��������Ʈ�� ��Һ��� ���� ���
                if (randomPoint < probs[i])
                {
                    switch (i)
                    {
                        case 0: //20f �ȿ� ��������Ʈ�� ������ ���
                            outsideShadow.SetActive(true);
                            outsideLaura.SetActive(false);
                            break;
                        case 1: //21f~50f �ȿ� ������ ���
                            outsideShadow.SetActive(false);
                            outsideLaura.SetActive(true);
                            break;
                        case 2: //51f~100f �ȿ� ������ ���
                            outsideShadow.SetActive(false);
                            outsideLaura.SetActive(false);
                            break;

                    }

                    return i;
                }
                else //��������Ʈ�� ��Һ��� ū ���
                {
                    //��������Ʈ�� 30�̸� probs[0]=20f, 30-20=10; �׷��� case:1�� ���� �ȴ�
                    randomPoint -= probs[i];
                }
            }
            return probs.Length - 1;
        }
    }


}
