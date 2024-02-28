using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Main : MonoBehaviour
{
    public SceneFader fader;

    [SerializeField]
    private string loadToScene = "2SelectSpring";


    void Start()
    {
        fader.InFade(0f); //���̵���

        //����� �÷���
        AudioManager.Instance.PlayBgm("MainMenu");
    }


    // �÷��� ��ư�� ���� ��
    public void Play()
    {
        AudioManager.Instance.Play("OptionButton"); // ȿ���� ���
        fader.FadeTo(loadToScene); //�� ����ȭ������ �̵�
    }


    // �ɼ� �������� ���� ��
    public void Options()
    {
        AudioManager.Instance.Play("OptionButton"); // ȿ���� ���
        //���� ȭ���� ���ξ����� ����
        PlayerPrefs.SetString("previoudScene", "1MainMenu");
        fader.FadeTo("1Options"); //�ɼ����� �̵��ϸ� ���̵�ƿ�
    }


    // ������ �ʱ�ȭ
    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Delete");
    }
}
