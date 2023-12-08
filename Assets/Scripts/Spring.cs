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

        if (!isPlay)
        {
            StartCoroutine(startNarra());
        }
        else
        {
            fader.InFade(0f);
            coll.enabled = false;
            Camera.main.GetComponent<shakeBox>().enabled = false;
            fadeImage.enabled = false;
            startText.enabled = false;
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

        isPlay = true;

        StopCoroutine(startNarra());
    }


    public void Options()
    {
        Debug.Log("ºº¿Ã∫Í");
        theSaveAndLoad.SaveData();

        fader.FadeTo("1Options");

        //Option.gameObject.SetActive(true);
    }


}
