using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    // 페이더 이미지( Color(R,G,B,A) : R 0~1, G 0~1, B 0~1, A 0~1 => 0:0, 1:255
    public Image Img;

    // 값(Value)을 커브값으로 환산대응
    public AnimationCurve curve;

    // 화면 밝기 설정 (0 : 투명, 0.5f: 약간 투명(약간 어둡게), 1f : 원래 이미지(검정))
    [SerializeField]
    private float colorAlpha = 0f;


    private void Start()
    {
        // 씬 시작하면 화면(이미지)이 무조건 검정색
        Img.color = new Color(0, 0, 0, 1);

    }


    // 페이드인 효과(화면이 켜짐)
    public void InFade(float fadeDelay)
    {
        StartCoroutine(FadeIn(fadeDelay));
    }


    // 씬 시작시 1초동안 페이드인 효과 (알파값 이용)
    IEnumerator FadeIn(float fadeDelay)
    {
        if(fadeDelay > 0)
        {
            //페이드 인을 지연시킬 시간
            yield return new WaitForSeconds(fadeDelay);
        }
        
        float t = 1f; // 검정 화면

        while (t > colorAlpha) // t에서 colorAlpha(0)값이 될 때까지 효과
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            Img.color = new Color(0, 0, 0, a);
            
            yield return 0; //다음 프레임까지 대기하고 루프를 계속 진행

        }

        //fadeIn 동안 다른 버튼이 안 눌리게 하는 등 추가

    }


    // 1초동안 페이드 아웃 - 씬 이동(string)
    public void FadeTo(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }


    // 씬 시작시 1초동안 페이드아웃 효과 후 씬 이동 (알파값 이동)
    IEnumerator FadeOut(string sceneName)
    {
        float t = Img.color.a;

        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            Img.color = new Color(0, 0, 0, a);
            
            yield return 0;
        }
        
        //fade out 동안 다른 버튼이 안 눌리게 하는 등 추가
        
        SceneManager.LoadScene(sceneName);
    }


    // fadeDelay동안 페이드아웃
    public void FadeTo(float fadeDelay)
    {
        StartCoroutine(FadeOut(fadeDelay));
    }


    // 씬 시작시 fadeDelay동안 페이드아웃 효과 
    IEnumerator FadeOut(float fadeDelay)
    {

        float t = Img.color.a; // 현재 화면의 값

        while (t < fadeDelay)
        {
            t += Time.deltaTime; // 시간의 흐름에 따라 t값을 증가
            float a = curve.Evaluate(t);
            Img.color = new Color(0, 0, 0, a);

            yield return 0;
        }

    }


    // springScene의 형광등 관련
    public void LightOn() //형광등 켜주기
    {
        Color light = Img.color;
        light.a = 0f;
        Img.color = light;

    }


    public void LightOff() //형광등 꺼주기
    {
        Color light = Img.color;
        light.a = 0.5f;
        Img.color = light;
    }

}
