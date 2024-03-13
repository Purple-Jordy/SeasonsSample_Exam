using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public SceneFader fader;
    private DisplayImage currentDisplay;

    private float initialCamerSize;
    private Vector3 initialCamerPosition;
    

    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCamerSize = Camera.main.orthographicSize;
        initialCamerPosition = Camera.main.transform.position;
    }


    //������ �̵� ��ư Ŭ��
    public void OnRightClickArrow()
    {
        StartCoroutine(Right());
    }


    // ���� �̵� ��ư Ŭ��
    public void OnLeftClickArrow()
    {
        StartCoroutine(Left());
    }


    // �ڷ� ���� ��ư Ŭ��
    public void OnClickReturn()
    {
        StartCoroutine(Back());
    }


    // ���� ���� ��ư Ŭ��
    public void OnClickUp()
    {
        StartCoroutine(Up());
    }


    IEnumerator Right()
    {
        //������ ȿ��
        fader.FadeTo(0.1f);

        yield return new WaitForSeconds(0.1f);

        fader.InFade(0f);


        //���� ChangedView ���¶��, 
        if (currentDisplay.CurrentState == DisplayImage.State.ChangedView)
        {
            //�ֱ��� ȭ������ �ٲ��ش�
            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
        }
        else if (currentDisplay.CurrentState == DisplayImage.State.zoom) //���� zoom ���¶��,
        {
            // ī�޶��� ��ġ�� Ȯ������ ������� �ٲ��ش�
            Camera.main.orthographicSize = initialCamerSize;
            Camera.main.transform.position = initialCamerPosition;
        }
        else // ���� ���� 1�� �����ش�
        {
            currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
        }


        //ȭ���� ���¸� normal�� �ٲ��ش�. 
        currentDisplay.CurrentState = DisplayImage.State.normal;

    }


    IEnumerator Left()
    {
        //������ ȿ��
        fader.FadeTo(0.1f);

        yield return new WaitForSeconds(0.1f);

        fader.InFade(0f);


        //���� ChangedView ���¶��, 
        if (currentDisplay.CurrentState == DisplayImage.State.ChangedView)
        {
            //�ֱ��� ȭ������ �ٲ��ش�
            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
        }
        else if (currentDisplay.CurrentState == DisplayImage.State.zoom) //���� zoom ���¶��,
        {
            // ī�޶��� ��ġ�� Ȯ������ ������� �ٲ��ش�
            Camera.main.orthographicSize = initialCamerSize;
            Camera.main.transform.position = initialCamerPosition;
        }
        else // ���� ������ 1�� ���ش�
        {
            currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
        }

        //ȭ���� ���¸� normal�� �ٲ��ش�. 
        currentDisplay.CurrentState = DisplayImage.State.normal;

    }



    IEnumerator Back()
    {
        //������ ȿ��
        fader.FadeTo(0.1f);

        yield return new WaitForSeconds(0.1f);

        fader.InFade(0f);


        //���� ���� ȭ�� ���°� �� ���¶��
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {

            // ī�޶� ���� ������� �ٲ��ش�. 
            Camera.main.orthographicSize = initialCamerSize;
            Camera.main.transform.position = initialCamerPosition;

        }
        else
        {
            //�ֱ��� ȭ������ �ٲ��ش�
            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);

        }

        //ȭ���� ���¸� normal�� �ٲ��ش�.
        currentDisplay.CurrentState = DisplayImage.State.normal;

    }


    IEnumerator Up()
    {
        //������ ȿ��
        fader.FadeTo(0.1f);

        yield return new WaitForSeconds(0.1f);

        fader.InFade(0f);


        // ȭ���� õ�� ���¶�� ȭ���� ���� �� �� �̹����� �ٲ��ش�. 
        if (currentDisplay.CurrentState == DisplayImage.State.ceiling)
        {
            currentDisplay.CurrentWall += 2;

            //ȭ���� ���¸� normal�� �ٲ��ش�. (���� �� ������ �̵��ϱ� ������)
            currentDisplay.CurrentState = DisplayImage.State.normal;
        }
        else
        {
            //���� ȭ���� �� ��ȣ�� ���� õ�� ȭ�鵵 �ٸ��� ������ ���� ȭ���� �� ���ڿ� ���� õ�� �̹����� �����´�
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/ceiling" + currentDisplay.CurrentWall.ToString());

            //ȭ���� ���¸� ceiling�� �ٲ��ش�. 
            currentDisplay.CurrentState = DisplayImage.State.ceiling;
        }

    }


}

