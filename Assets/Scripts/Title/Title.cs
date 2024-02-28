using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class Title : MonoBehaviour
{
    public SceneFader fader;

    [SerializeField]
    private string loadToScene = "1MainMenu";


    public TextMeshProUGUI text;
    private string m_text = "RUSTY  LAKE";



    void Start()
    {
        fader.InFade(0f); //페이드 인 시작
        StartCoroutine(Typing()); // 타이핑 코루틴 시작
    }


    IEnumerator Typing()
    {
        //배경음 플레이
        AudioManager.Instance.Play("titleSound");

        yield return new WaitForSeconds(2.8f);

        // 한글자씩 나오게 하는 코루틴
        for(int i = 0; i < m_text.Length; i++)
        {
            text.text = m_text.Substring(0, i+1);

            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(1f);

        //페이드 아웃하면서 씬 이동
        fader.FadeTo(loadToScene);
    }


}
