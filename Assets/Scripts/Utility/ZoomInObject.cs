using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable //�������̽� ���
{

    // ī�޶� ������ ����
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
            //ȭ���� �� ���°� �ƴϸ� �ݶ��̴� ���ֱ�
            this.GetComponent<BoxCollider2D>().enabled = true;
        }

    }


    // �� ������Ʈ Ŭ�� ��(�������̽� ���)
    public void interact(DisplayImage currentDisplay)
    {
        //ī�޶��� ��ġ�� �� ������Ʈ�� ��ġ�� �ٲ۴�
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            Camera.main.transform.position.z);

        // ī�޶��� ����� ������ ������ �ٲ��ش�
        Camera.main.orthographicSize = moveCamSize; 

        //ȭ���� ���¸� ������ �ٲ۴�
        currentDisplay.CurrentState = DisplayImage.State.zoom;

        //Ŭ�� �̺�Ʈ�� �ɸ��� �ʰ� �ݶ��̴� ���ֱ�
        this.GetComponent<BoxCollider2D>().enabled = false;
        
    }


}
