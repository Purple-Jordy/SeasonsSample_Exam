using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SelectSpring : MonoBehaviour
{
    public SceneFader fader;


    void Start()
    {
        fader.InFade(0.3f); // 페이드인
        AudioManager.Instance.PlayBgm("selectScene"); // 배경음 재생
    }


    //옵션 버튼 누를 시
    public void Options()
    {
        AudioManager.Instance.Play("OptionButton"); //효과음 재생
        PlayerPrefs.SetString("previoudScene", "2SelectSpring"); // 이전 씬 데이터 저장
        fader.FadeTo("1Options"); //옵션으로 이동
    }

}
