using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public SceneFader fader;

    private LoadData loadData;

    [SerializeField]
    private string loadToScene = "1MainMenu";


    void Start()
    {
        fader.InFade(0.1f); //페이드인

        //배경음 플레이
        AudioManager.Instance.PlayBgm("MainMenu");

        loadData = FindObjectOfType<LoadData>(); //LoadData 오브젝트 찾기
    }

    // 뒤로 돌아가기
    public void Back()
    {
        AudioManager.Instance.Play("OptionButton"); //효과음 재생
        StartCoroutine(BackPlayScene()); // BackPlayScene 코루틴 실행
    }


    IEnumerator BackPlayScene()
    {
        // 이전의 씬이 메인 메뉴가 아닌 경우 (이전 씬이 springScene이거나 selectSpring이었을 경우)
        if (PlayerPrefs.GetString("previoudScene") != "1MainMenu")
        {
            fader.FadeTo(1f);

            yield return new WaitForSeconds(1f);

            loadData.ClickLoad(); //SpringScene 로드
        }
        else // 메인메뉴로 이동
        {
            fader.FadeTo(loadToScene);
        }

    }


    // 그만두기를 눌렀을 경우
    public void QuitGame()
    {
        AudioManager.Instance.Play("OptionButton"); //효과음 재생
        StartCoroutine(OutHere()); // OutHere 코루틴 시작
    }


    // 메뉴 버튼을 눌렀을 경우
    public void GoToMenu()
    {
        AudioManager.Instance.Play("OptionButton"); // 효과음 재생
        fader.FadeTo(loadToScene); // 메인 메뉴로 이동
    }
    

    IEnumerator OutHere()
    {
        fader.FadeTo(1f);

        yield return new WaitForSeconds(1f);

        Debug.Log("Quit Game");
        Application.Quit();
    }


}
