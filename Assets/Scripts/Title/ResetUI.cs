using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUI : MonoBehaviour
{

    public GameObject askUI;
    private Animator animator;


    private void Start()
    {
        animator = askUI.GetComponent<Animator>();  
    }


    // �ʱ�ȭ ��ư ���� ��, �ٽ� �� �� ���� â ������
    public void OpenAsk()
    {
        AudioManager.Instance.Play("OptionButton"); //ȿ���� ���
        askUI.SetActive(true); // �ٽ� �� �� ����� â �ѱ�
    }


    // �ƴϿ� ��ư ���� ��
    public void NoButton()
    {
        AudioManager.Instance.Play("OptionButton"); //ȿ���� ���
        StartCoroutine(AskOff()); // AskOff �ڷ�ƾ ����

        // �� ��ư�� ���� �� ������ ���� ��ũ��Ʈ saveAndLoad���� �ʱ�ȭ
    }


    IEnumerator AskOff()
    {
        animator.SetBool("ask", true); // ������ �ִϸ��̼� ���

        yield return new WaitForSeconds(0.3f);

        askUI.SetActive(false); // ����� â ����
    }
}
