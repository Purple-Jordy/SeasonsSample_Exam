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
        // 이전 설정 데이터 불러오기
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


    // BgmOn 버튼 눌러서 bgm 끄기
    public void BgmOff()
    {
        AudioManager.Instance.Play("OptionButton"); //효과음 재생
        audioMixer.SetFloat("BGM", -40f); //음량 안 들리게 줄이기
        bgmOff.SetActive(true); // bgmOff 이미지로 교체
        bgmOn.SetActive(false); // bgmOn 이미지 끄기 
        PlayerPrefs.SetString("bgm", "off"); // 데이터 저장
    }

    // BgmOff 버튼 눌러서 bgm 켜기
    public void BgmOn()
    {
        AudioManager.Instance.Play("OptionButton"); // 효과음 재생
        audioMixer.SetFloat("BGM", 0.6f); // 음량 들리게 올리기
        bgmOn.SetActive(true); // bgmOn 이미지로 교체
        bgmOff.SetActive(false); // bgmOff 이미지 끄기
        PlayerPrefs.SetString("bgm", "on"); // 데이터 저장
    }

}
