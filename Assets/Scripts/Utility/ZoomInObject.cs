using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable
{

    //public BoxCollider2D bound; // Map bound
    private Vector3 minBound;  // Map�� ���� �Ʒ�
    private Vector3 maxBound; // Map�� ������ ��
    private float halfWidth; // ī�޶� ������ ����
    private float halfHeight; // ī�޶� ������ ����


    // ī�޶� ������
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
            //ȭ���� Ȯ�밡 �ƴϸ� �ݶ��̴� ���ֱ�
            this.GetComponent<BoxCollider2D>().enabled = true;
        }

    }


    public void interact(DisplayImage currentDisplay)
    {

        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            Camera.main.transform.position.z);

        Camera.main.orthographicSize = moveCamSize; 

        //ȭ���� ���¸� ������ �ٲ۴�
        currentDisplay.CurrentState = DisplayImage.State.zoom;

        //Ŭ�� �̺�Ʈ�� �ɸ��� �ʰ� �ݶ��̴� ���ֱ�
        this.GetComponent<BoxCollider2D>().enabled = false;
        
    }


  
}
