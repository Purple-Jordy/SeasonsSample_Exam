using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spring : MonoBehaviour
{
    public SceneFader fader;
    public TextMeshProUGUI startText;
    private BoxCollider2D coll;

    [SerializeField] private SaveAndLoad theSaveAndLoad;
    public GameObject Option;
    public GameObject fade;
    public Animator fadeAnim;

    public static bool isPlay = false;
    public GameObject OptionButton;




    void Start()
    {
        //��ġ ����
        coll = GetComponent<BoxCollider2D>();

        //����� �÷���
        AudioManager.Instance.PlayBgm("springScene");

        StartCoroutine(startNarra());

       

    }


    IEnumerator startNarra()
    {
        yield return new WaitForSeconds(0.1f);
        
        
        if (isPlay == true)
        {
            fader.InFade(0.2f); // ȭ�� ��� 
            coll.enabled = false; // ��ġ ����
            Camera.main.GetComponent<shakeBox>().enabled = false; //����ũ �ڽ� ���ֱ�
            fadeAnim.enabled = false; //���̵� �̹��� ���ֱ�
            startText.enabled = false; //���� �۾� ���ֱ� 
        }
        else
        {
            OptionButton.SetActive(false);
            startText.enabled = true;
            Camera.main.GetComponent<shakeBox>().enabled = true; //����ũ �ڽ� ���ֱ�

            yield return new WaitForSeconds(3f);

            fader.InFade(0f);
            startText.enabled = false;
            fadeAnim.enabled = true;


            yield return new WaitForSeconds(1f);

            OptionButton.SetActive(true);
            coll.enabled = false;
            Camera.main.GetComponent<shakeBox>().enabled = false;
            fadeAnim.enabled = false;

            isPlay = true;

        }




    }


    public void Options()
    {
        AudioManager.Instance.Play("OptionButton");
        Debug.Log("���̺�");
        theSaveAndLoad.SaveData();

        PlayerPrefs.SetString("previoudScene", "2SpringScene");
        fader.FadeTo("1Options");

        //Option.gameObject.SetActive(true);
    }


}
