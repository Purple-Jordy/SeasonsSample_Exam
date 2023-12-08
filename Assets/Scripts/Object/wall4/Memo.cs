using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Memo : MonoBehaviour, IInteractable
{
    //메모 내용 보이기
    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;

    // 게시판 범위
    public BoxCollider2D bound; // 게시판 콜라이더
    private Vector3 minBound;  // 게시판의 왼쪽 아래
    private Vector3 maxBound; // 게시판의 오른쪽 위
    
    //오브젝트 콜라이더
    private float halfWidth; // 메모 가로의 절반
    private float halfHeight; // 메모 세로의 절반

    private PolygonCollider2D coll;

    private DisplayImage currentDisplay;

    // 메모 내용
    [SerializeField]
    private string memoText;


    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        coll = this.gameObject.GetComponent<PolygonCollider2D>();

        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        halfWidth = coll.bounds.extents.x;
        halfHeight = coll.bounds.extents.y;

        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

    }


    // 메모 드래그
    void OnMouseDrag() //콜라이더가 반드시 있어야한다!
    {
        //화면이 zoom 상태일때만 움직이게
        if(currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            MemoMove();
        }

    }


    //메모 클릭
    public void interact(DisplayImage currentDisplay)
    {
        //화면이 zoom 상태일 때만 글씨 나오게 
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            UIAnimator.Play("ShowItemNameAnim", -1, 0f);
            situationText.text = memoText;
        }
    }


    void MemoMove()
    {
        //마우스 위치를 받아서 월드좌표로 바꿔준다
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -2);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // 받아온 마우스 위치가 범위(게시판) 안에 있다면 그 범위가 오브젝트의 위치
        float clampX = Mathf.Clamp(objPosition.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampY = Mathf.Clamp(objPosition.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        // 터치 값은 z값에 영향을 받음. z값이 0보다 작아야 값이 입력 받아짐
        this.transform.position = new Vector3(clampX, clampY, -2f);

    }

    


}
