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

    private LoadData loadData; // �� ������ ����


    public void Start()
    {
        // �ʱ�ȭ
        startPosition = transform.position;
        loadData = FindObjectOfType<LoadData>(); // ������Ʈ ã��
    }


    public virtual void Update()
    {
        //ȭ�� Ŭ�� üũ
        if (Input.GetMouseButtonDown(0))
        {
            // ī�޶󿡼� ���콺 ������ ��ġ�� ���̸� �߻�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // ��ü�� Ray�� �浹�� ���� ��� ������ �����ϴ� ����ü

            if (Physics.Raycast(ray, out hit)) //�浹�� �ִٸ�
            {
                Debug.Log(hit.transform.gameObject);

                if (hit.transform.gameObject.tag == "Cube") // �浹ü�� �±װ� ť����
                {
                    AudioManager.Instance.Play("OptionButton"); //ȿ���� ���
                    StartCoroutine(startGame()); // startGame �ڷ�ƾ ����

                }
            }

        }

        // ť�� ȸ��
        Rotate();

    }


    // ť�� ȸ��
    public void Rotate()
    {
        // �� �Ʒ� ��鸲
        float bobingAnimationPhase = Mathf.Sin(verticalBobFrequency * Time.time) * bobingAmount;
        transform.position = startPosition + Vector3.up * bobingAnimationPhase;

        // ť�� ȸ��
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }


    // ���� ���� �ڷ�ƾ 
    IEnumerator startGame()
    {

        fader.FadeTo(1f); // ���̵� �ƿ�

        yield return new WaitForSeconds(1f);

        loadData.ClickLoad(); //������ �ҷ����鼭 springScene���� �̵�

    }
  
}
