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
    private float colorAlpha = 0f;


    private void Start()
    {
        // �� �����ϸ� ȭ��(�̹���)�� ������ ������
        Img.color = new Color(0, 0, 0, 1);

    }


    // ���̵��� ȿ��(ȭ���� ����)
    public void InFade(float fadeDelay)
    {
        StartCoroutine(FadeIn(fadeDelay));
    }


    // �� ���۽� 1�ʵ��� ���̵��� ȿ�� (���İ� �̿�)
    IEnumerator FadeIn(float fadeDelay)
    {
        if(fadeDelay > 0)
        {
            //���̵� ���� ������ų �ð�
            yield return new WaitForSeconds(fadeDelay);
        }
        
        float t = 1f; // ���� ȭ��

        while (t > colorAlpha) // t���� colorAlpha(0)���� �� ������ ȿ��
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            Img.color = new Color(0, 0, 0, a);
            
            yield return 0; //���� �����ӱ��� ����ϰ� ������ ��� ����

        }

        //fadeIn ���� �ٸ� ��ư�� �� ������ �ϴ� �� �߰�

    }


    // 1�ʵ��� ���̵� �ƿ� - �� �̵�(string)
    public void FadeTo(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }


    // �� ���۽� 1�ʵ��� ���̵�ƿ� ȿ�� �� �� �̵� (���İ� �̵�)
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
        
        //fade out ���� �ٸ� ��ư�� �� ������ �ϴ� �� �߰�
        
        SceneManager.LoadScene(sceneName);
    }


    // fadeDelay���� ���̵�ƿ�
    public void FadeTo(float fadeDelay)
    {
        StartCoroutine(FadeOut(fadeDelay));
    }


    // �� ���۽� fadeDelay���� ���̵�ƿ� ȿ�� 
    IEnumerator FadeOut(float fadeDelay)
    {

        float t = Img.color.a; // ���� ȭ���� ��

        while (t < fadeDelay)
        {
            t += Time.deltaTime; // �ð��� �帧�� ���� t���� ����
            float a = curve.Evaluate(t);
            Img.color = new Color(0, 0, 0, a);

            yield return 0;
        }

    }


    // springScene�� ������ ����
    public void LightOn() //������ ���ֱ�
    {
        Color light = Img.color;
        light.a = 0f;
        Img.color = light;

    }


    public void LightOff() //������ ���ֱ�
    {
        Color light = Img.color;
        light.a = 0.5f;
        Img.color = light;
    }

}
