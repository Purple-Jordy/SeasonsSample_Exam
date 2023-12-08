using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Memo : MonoBehaviour, IInteractable
{
    //�޸� ���� ���̱�
    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;

    // �Խ��� ����
    public BoxCollider2D bound; // �Խ��� �ݶ��̴�
    private Vector3 minBound;  // �Խ����� ���� �Ʒ�
    private Vector3 maxBound; // �Խ����� ������ ��
    
    //������Ʈ �ݶ��̴�
    private float halfWidth; // �޸� ������ ����
    private float halfHeight; // �޸� ������ ����

    private PolygonCollider2D coll;

    private DisplayImage currentDisplay;

    // �޸� ����
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


    // �޸� �巡��
    void OnMouseDrag() //�ݶ��̴��� �ݵ�� �־���Ѵ�!
    {
        //ȭ���� zoom �����϶��� �����̰�
        if(currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            MemoMove();
        }

    }


    //�޸� Ŭ��
    public void interact(DisplayImage currentDisplay)
    {
        //ȭ���� zoom ������ ���� �۾� ������ 
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            UIAnimator.Play("ShowItemNameAnim", -1, 0f);
            situationText.text = memoText;
        }
    }


    void MemoMove()
    {
        //���콺 ��ġ�� �޾Ƽ� ������ǥ�� �ٲ��ش�
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -2);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // �޾ƿ� ���콺 ��ġ�� ����(�Խ���) �ȿ� �ִٸ� �� ������ ������Ʈ�� ��ġ
        float clampX = Mathf.Clamp(objPosition.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampY = Mathf.Clamp(objPosition.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        // ��ġ ���� z���� ������ ����. z���� 0���� �۾ƾ� ���� �Է� �޾���
        this.transform.position = new Vector3(clampX, clampY, -2f);

    }

    


}
