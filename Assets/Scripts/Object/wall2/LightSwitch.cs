using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour, IInteractable
{
    public SceneFader fader;

    // ������ ���� �ִ��� Ȯ��
    public static bool lightOn = false;


    private void Start()
    {
        // �ʱ�ȭ(���� off ����)
        lightOn = false;


    }


    //Ŭ���� �Ͼ�� �� - ���� on off
    public void interact(DisplayImage currentDisplay)
    {
        if(lightOn) //���� ���� �ִ� ���¸�
        {
            fader.LightOff(); //���̴��� ��Ӱ�

            // ����ġ off �̹����� ��ü
            this.gameObject.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/lightSwitchOff"); 
            
            //lightOn false�� �ٲ��ֱ�
            lightOn = false;
        }
        else //������ ���� ������
        {
            fader.LightOn(); // ���̴��� ���

            // ����ġ on �̹����� ��ü
            this.gameObject.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/lightSwitchOn");

            //lightOn true�� �ٲ��ֱ�
            lightOn = true;
        }

        //ȿ���� �÷���
        AudioManager.Instance.Play("lightOnOff");
    }

    
}
