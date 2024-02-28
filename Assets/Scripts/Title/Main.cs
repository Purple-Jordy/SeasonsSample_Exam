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
        fader.InFade(0f); //페이드인

        //배경음 플레이
        AudioManager.Instance.PlayBgm("MainMenu");
    }


    // 플레이 버튼을 누를 때
    public void Play()
    {
        AudioManager.Instance.Play("OptionButton"); // 효과음 재생
        fader.FadeTo(loadToScene); //씬 선택화면으로 이동
    }


    // 옵션 아이콘을 누를 때
    public void Options()
    {
        AudioManager.Instance.Play("OptionButton"); // 효과음 재생
        //이전 화면이 메인씬임을 저장
        PlayerPrefs.SetString("previoudScene", "1MainMenu");
        fader.FadeTo("1Options"); //옵션으로 이동하며 페이드아웃
    }


    // 데이터 초기화
    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Delete");
    }
}
