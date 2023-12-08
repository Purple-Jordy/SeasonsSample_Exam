using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    // ���̴� �̹���( Color(R,G,B,A) : R 0~1, G 0~1, B 0~1, A 0~1 => 0:0, 1:255
    public Image Img;

    // ��(Value)�� Ŀ�갪���� ȯ�����
    public AnimationCurve curve;

    // ȭ�� ��� ���� (0 : ����, 0.5f: �ణ ����(�ణ ��Ӱ�), 1f : ���� �̹���(����))
    [SerializeField]
    private float colorAlpha = 1f;


    private void Start()
    {
        
        // �����ϸ� ������ ȭ���� ������
        Img.color = new Color(0, 0, 0, 1);

        //InFade(1f);
    }


    public void InFade(float fadeDelay)
    {
        StartCoroutine(FadeIn(fadeDelay));
    }


    // �� ���۽� 1�ʵ��� ���̵��� ȿ�� (���İ� �̿�)
    IEnumerator FadeIn(float fadeDelay)
    {
        if(fadeDelay > 0)
        {
            yield return new WaitForSeconds(fadeDelay);
        }
        
        float t = 1f;

        while (t > colorAlpha) //t���� colorAlpha���� ������ ȿ��
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            Img.color = new Color(0, 0, 0, a);
            
            yield return 0;

        }

    }


    // �� �̵�(string)
    public void FadeTo(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }




    // �� ���۽� 1�ʵ��� ���̵�ƿ� ȿ�� �� �� �̵� (���İ� �̵�)
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
        // ESC ��ư �� ������
        
        SceneManager.LoadScene(sceneName);
    }


    // �� �̵�(int)
    public void FadeTo(int sceneNunmber)
    {
        StartCoroutine(FadeOut(sceneNunmber));
    }



    // �� ���۽� 1�ʵ��� ���̵�ƿ� ȿ�� �� �� �̵� (���İ� �̵�)
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
        // ESC ��ư �� ������
        
        SceneManager.LoadScene(sceneNunmber);
    }


    // 
    public void FadeTo()
    {
        StartCoroutine(FadeOut());
    }


    // �� ���۽� 1�ʵ��� ���̵�ƿ� ȿ�� 
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
