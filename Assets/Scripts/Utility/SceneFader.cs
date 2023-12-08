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
    private float colorAlpha = 1f;


    private void Start()
    {
        
        // 시작하면 무조건 화면이 검정색
        Img.color = new Color(0, 0, 0, 1);

        //InFade(1f);
    }


    public void InFade(float fadeDelay)
    {
        StartCoroutine(FadeIn(fadeDelay));
    }


    // 씬 시작시 1초동안 페이드인 효과 (알파값 이용)
    IEnumerator FadeIn(float fadeDelay)
    {
        if(fadeDelay > 0)
        {
            yield return new WaitForSeconds(fadeDelay);
        }
        
        float t = 1f;

        while (t > colorAlpha) //t에서 colorAlpha값될 때까지 효과
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            Img.color = new Color(0, 0, 0, a);
            
            yield return 0;

        }

    }


    // 씬 이동(string)
    public void FadeTo(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }




    // 씬 시작시 1초동안 페이드아웃 효과 후 씬 이동 (알파값 이동)
    IEnumerator FadeOut(string sceneName)
    {
        float t = colorAlpha;
        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            Img.color = new Color(0, 0, 0, a);
            
            yield return 0;
        }
        // ESC 버튼 안 눌리게
        
        SceneManager.LoadScene(sceneName);
    }


    // 씬 이동(int)
    public void FadeTo(int sceneNunmber)
    {
        StartCoroutine(FadeOut(sceneNunmber));
    }



    // 씬 시작시 1초동안 페이드아웃 효과 후 씬 이동 (알파값 이동)
    IEnumerator FadeOut(int sceneNunmber)
    {
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            Img.color = new Color(0, 0, 0, a);
            
            yield return 0;
        }
        // ESC 버튼 안 눌리게
        
        SceneManager.LoadScene(sceneNunmber);
    }


    // 
    public void FadeTo()
    {
        StartCoroutine(FadeOut());
    }


    // 씬 시작시 1초동안 페이드아웃 효과 
    IEnumerator FadeOut()
    {
        float t = colorAlpha;
        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            Img.color = new Color(0, 0, 0, a);

            yield return 0;
        }


    }



    public void LightOn()
    {
        Color light = Img.color;
        light.a = 0f;
        colorAlpha = 0f;
        Img.color = light;

    }


    public void LightOff()
    {
        Color light = Img.color;
        light.a = 0.5f;
        colorAlpha = 0.5f;
        Img.color = light;
    }

}
