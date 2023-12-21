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
    public Animator fadeImage;

    public static bool isPlay = false;



    void Start()
    {
        startText.enabled = true;
        coll = GetComponent<BoxCollider2D>();

        //배경음 플레이
        AudioManager.Instance.PlayBgm("springScene");

        if (PlayerPrefs.HasKey("isPlay"))
        {
            if (PlayerPrefs.GetInt("isPlay") == 1)
            {
                fader.InFade(0.2f);
                coll.enabled = false;
                Camera.main.GetComponent<shakeBox>().enabled = false;
                fadeImage.enabled = false;
                startText.enabled = false;
            }
            else
            {
                StartCoroutine(startNarra());

            }
        }
        else
        {
            StartCoroutine(startNarra());
            
        }
    }




    IEnumerator startNarra()
    {

        yield return new WaitForSeconds(3f);

        fader.InFade(0f);
        startText.enabled = false;
        fadeImage.enabled = true;
       

        yield return new WaitForSeconds(1f);


        coll.enabled = false;
        Camera.main.GetComponent<shakeBox>().enabled = false;
        fadeImage.enabled = false;

        //isPlay = true;
        PlayerPrefs.SetInt("isPlay", 1);
        theSaveAndLoad.SaveData();

        //StopCoroutine(startNarra());
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
