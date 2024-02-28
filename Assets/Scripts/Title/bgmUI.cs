using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class bgmUI : MonoBehaviour
{
    public GameObject bgmOn;
    public GameObject bgmOff;
    public AudioMixer audioMixer;


    private void Start()
    {
        // ���� ���� ������ �ҷ�����
        if(PlayerPrefs.GetString("bgm") == "off")
        {
            bgmOff.SetActive(true);
            bgmOn.SetActive(false);
        }
        else if(PlayerPrefs.GetString("bgm") == "on")
        {
            bgmOn.SetActive(true);
            bgmOff.SetActive(false);
        }   
    }


    // BgmOn ��ư ������ bgm ����
    public void BgmOff()
    {
        AudioManager.Instance.Play("OptionButton"); //ȿ���� ���
        audioMixer.SetFloat("BGM", -40f); //���� �� �鸮�� ���̱�
        bgmOff.SetActive(true); // bgmOff �̹����� ��ü
        bgmOn.SetActive(false); // bgmOn �̹��� ���� 
        PlayerPrefs.SetString("bgm", "off"); // ������ ����
    }

    // BgmOff ��ư ������ bgm �ѱ�
    public void BgmOn()
    {
        AudioManager.Instance.Play("OptionButton"); // ȿ���� ���
        audioMixer.SetFloat("BGM", 0.6f); // ���� �鸮�� �ø���
        bgmOn.SetActive(true); // bgmOn �̹����� ��ü
        bgmOff.SetActive(false); // bgmOff �̹��� ����
        PlayerPrefs.SetString("bgm", "on"); // ������ ����
    }

}
