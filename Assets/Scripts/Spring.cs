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
        //터치 막기
        coll = GetComponent<BoxCollider2D>();

        //배경음 플레이
        AudioManager.Instance.PlayBgm("springScene");

        StartCoroutine(startNarra());

       

    }


    IEnumerator startNarra()
    {
        yield return new WaitForSeconds(0.1f);
        
        
        if (isPlay == true)
        {
            fader.InFade(0.2f); // 화면 밝게 
            coll.enabled = false; // 터치 가능
            Camera.main.GetComponent<shakeBox>().enabled = false; //셰이크 박스 꺼주기
            fadeAnim.enabled = false; //페이드 이미지 꺼주기
            startText.enabled = false; //시작 글씨 꺼주기 
        }
        else
        {
            OptionButton.SetActive(false);
            startText.enabled = true;
            Camera.main.GetComponent<shakeBox>().enabled = true; //셰이크 박스 꺼주기

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
        Debug.Log("세이브");
        theSaveAndLoad.SaveData();

        PlayerPrefs.SetString("previoudScene", "2SpringScene");
        fader.FadeTo("1Options");

        //Option.gameObject.SetActive(true);
    }


}
