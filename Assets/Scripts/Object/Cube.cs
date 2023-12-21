using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    public SceneFader fader;

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

    private Title1 title1;


    public void Start()
    {
        // �ʱ�ȭ
        startPosition = transform.position;
        title1 = FindObjectOfType<Title1>();
    }


    public virtual void Update()
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
                    AudioManager.Instance.Play("OptionButton");
                    StartCoroutine(startGame());
                    
                }
            }

        }

        Rotate();

    }


    public void Rotate()
    {
        // �� �Ʒ� ��鸲
        float bobingAnimationPhase = Mathf.Sin(verticalBobFrequency * Time.time) * bobingAmount;
        transform.position = startPosition + Vector3.up * bobingAnimationPhase;

        //ȸ��
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }


    IEnumerator startGame()
    {

        fader.FadeTo();

        yield return new WaitForSeconds(1f);

        title1.ClickLoad();

    }
  
}
