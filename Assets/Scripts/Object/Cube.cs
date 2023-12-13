using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    public SceneFader fader;

    [SerializeField]
    private string loadToScene = "2SpringScene";

    // ���Ʒ� ��鸲 �ӵ�
    [SerializeField]
    private float verticalBobFrequency = 1f;

    // ���Ʒ� ��鸲 ������
    [SerializeField]
    private float bobingAmount = 1f;

    //ȸ��
    [SerializeField]
    private float rotateSpeed = 10;

    // ó�� ��ġ 
    private Vector3 startPosition;

   


    void Start()
    {
        // �ʱ�ȭ
        startPosition = transform.position;
    }

    void Update()
    {
        //ȭ�� Ŭ�� üũ
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);

                if (hit.transform.gameObject.tag == "Cube") // ť�� Ŭ�� ��
                {

                    
                    //StartCoroutine(Click());
                    //Title1.instance.ClickLoad();

                    fader.FadeTo(loadToScene);
                }
            }

        }

        Rotate();

    }

    private void Rotate()
    {
        // �� �Ʒ� ��鸲
        float bobingAnimationPhase = Mathf.Sin(verticalBobFrequency * Time.time) * bobingAmount;
        transform.position = startPosition + Vector3.up * bobingAnimationPhase;

        //ȸ��
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }


  
}
