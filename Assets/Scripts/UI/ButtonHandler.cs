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


    //오른쪽 이동 버튼 클릭
    public void OnRightClickArrow()
    {
        StartCoroutine(Right());
    }


    // 왼쪽 이동 버튼 클릭
    public void OnLeftClickArrow()
    {
        StartCoroutine(Left());
    }


    // 뒤로 가기 버튼 클릭
    public void OnClickReturn()
    {
        StartCoroutine(Back());
    }


    // 위로 가기 버튼 클릭
    public void OnClickUp()
    {
        StartCoroutine(Up());
    }


    IEnumerator Right()
    {
        //깜빡임 효과
        fader.FadeTo(0.1f);

        yield return new WaitForSeconds(0.1f);

        fader.InFade(0f);


        //만약 ChangedView 상태라면, 
        if (currentDisplay.CurrentState == DisplayImage.State.ChangedView)
        {
            //최근의 화면으로 바꿔준다
            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
        }
        else if (currentDisplay.CurrentState == DisplayImage.State.zoom) //만약 zoom 상태라면,
        {
            // 카메라의 위치와 확대사이즈를 원래대로 바꿔준다
            Camera.main.orthographicSize = initialCamerSize;
            Camera.main.transform.position = initialCamerPosition;
        }
        else // 현재 벽에 1을 더해준다
        {
            currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
        }


        //화면의 상태를 normal로 바꿔준다. 
        currentDisplay.CurrentState = DisplayImage.State.normal;

    }


    IEnumerator Left()
    {
        //깜빡임 효과
        fader.FadeTo(0.1f);

        yield return new WaitForSeconds(0.1f);

        fader.InFade(0f);


        //만약 ChangedView 상태라면, 
        if (currentDisplay.CurrentState == DisplayImage.State.ChangedView)
        {
            //최근의 화면으로 바꿔준다
            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
        }
        else if (currentDisplay.CurrentState == DisplayImage.State.zoom) //만약 zoom 상태라면,
        {
            // 카메라의 위치와 확대사이즈를 원래대로 바꿔준다
            Camera.main.orthographicSize = initialCamerSize;
            Camera.main.transform.position = initialCamerPosition;
        }
        else // 현재 벽에서 1을 빼준다
        {
            currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
        }

        //화면의 상태를 normal로 바꿔준다. 
        currentDisplay.CurrentState = DisplayImage.State.normal;

    }



    IEnumerator Back()
    {
        //깜빡임 효과
        fader.FadeTo(0.1f);

        yield return new WaitForSeconds(0.1f);

        fader.InFade(0f);


        //만약 현재 화면 상태가 줌 상태라면
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {

            // 카메라를 원래 사이즈로 바꿔준다. 
            Camera.main.orthographicSize = initialCamerSize;
            Camera.main.transform.position = initialCamerPosition;

        }
        else
        {
            //최근의 화면으로 바꿔준다
            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);

        }

        //화면의 상태를 normal로 바꿔준다.
        currentDisplay.CurrentState = DisplayImage.State.normal;

    }


    IEnumerator Up()
    {
        //깜빡임 효과
        fader.FadeTo(0.1f);

        yield return new WaitForSeconds(0.1f);

        fader.InFade(0f);


        // 화면이 천장 상태라면 화면을 맞은 편 벽 이미지로 바꿔준다. 
        if (currentDisplay.CurrentState == DisplayImage.State.ceiling)
        {
            currentDisplay.CurrentWall += 2;

            //화면의 상태를 normal로 바꿔준다. (맞은 편 벽으로 이동하기 때문에)
            currentDisplay.CurrentState = DisplayImage.State.normal;
        }
        else
        {
            //이전 화면의 벽 번호에 따라 천장 화면도 다르기 때문에 이전 화면의 벽 숫자에 따른 천장 이미지를 가져온다
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/ceiling" + currentDisplay.CurrentWall.ToString());

            //화면의 상태를 ceiling로 바꿔준다. 
            currentDisplay.CurrentState = DisplayImage.State.ceiling;
        }

    }


}

