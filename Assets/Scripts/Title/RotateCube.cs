using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
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


    private void Start()
    {
        // �ʱ�ȭ
        startPosition = transform.position;
    }


    private void Update()
    {
        // �� �Ʒ� ��鸲
        float bobingAnimationPhase = Mathf.Sin(verticalBobFrequency * Time.time) * bobingAmount;
        transform.position = startPosition + Vector3.up * bobingAnimationPhase;

        //ȸ��
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

    }

}