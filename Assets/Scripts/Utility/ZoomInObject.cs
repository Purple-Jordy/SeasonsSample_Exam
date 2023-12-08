using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable
{

    //public BoxCollider2D bound; // Map bound
    private Vector3 minBound;  // Map의 왼쪽 아래
    private Vector3 maxBound; // Map의 오른쪽 위
    private float halfWidth; // 카메라 가로의 절반
    private float halfHeight; // 카메라 세로의 절반


    // 카메라 사이즈
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
            //화면이 확대가 아니면 콜라이더 켜주기
            this.GetComponent<BoxCollider2D>().enabled = true;
        }

    }


    public void interact(DisplayImage currentDisplay)
    {

        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            Camera.main.transform.position.z);

        Camera.main.orthographicSize = moveCamSize; 

        //화면의 상태를 줌으로 바꾼다
        currentDisplay.CurrentState = DisplayImage.State.zoom;

        //클릭 이벤트에 걸리지 않게 콜라이더 꺼주기
        this.GetComponent<BoxCollider2D>().enabled = false;
        
    }


  
}
