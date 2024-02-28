using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    public static MousePointer instance;

    public GameObject circle; //Ŭ���� �� �˷��ִ� ��
    private Animator animator; //�� ����� �ִϸ��̼�


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }


    private void Start()
    {
        animator = circle.GetComponent<Animator>();
    }


    void Update()
    {
        //ȭ�� Ŭ���� Ŭ���� ���� �˷��ִ� �� ���� �ִϸ��̼� ���
        if (Input.GetMouseButtonDown(0))
        {
            circle.transform.position = Input.mousePosition; //�� ���� ��ġ�� Ŭ�� ��ġ

            animator.Play("mouseAnim", -1, 0f); // Ŭ���� �ٷ� ó������ ����ǰ�
            
        }
    }

    
}
