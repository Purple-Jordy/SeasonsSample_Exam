using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable //인터페이스 상속
{

    // 카메라 사이즈 변수
    [SerializeField]
    private float moveCamSize = 1f;

    private DisplayImage displayImage;


    private void Start()
    {
        displayImage = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    private void Update()
    {
        if(displayImage.CurrentState != DisplayImage.State.zoom)
        {
            //화면이 줌 상태가 아니면 콜라이더 켜주기
            this.GetComponent<BoxCollider2D>().enabled = true;
        }

    }


    // 줌 오브젝트 클릭 시(인터페이스 상속)
    public void interact(DisplayImage currentDisplay)
    {
        //카메라의 위치를 줌 오브젝트의 위치로 바꾼다
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            Camera.main.transform.position.z);

        // 카메라의 사이즈도 설정한 값으로 바꿔준다
        Camera.main.orthographicSize = moveCamSize; 

        //화면의 상태를 줌으로 바꾼다
        currentDisplay.CurrentState = DisplayImage.State.zoom;

        //클릭 이벤트에 걸리지 않게 콜라이더 꺼주기
        this.GetComponent<BoxCollider2D>().enabled = false;
        
    }


}
