using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public SceneFader fader;

    private Title1 title1;

    [SerializeField]
    private string loadToScene = "1MainMenu";


    //옵션
   /* public GameObject optionsUI;
    public Slider bgmSlider;
    public Slider sfxSlider;
   */

    //public AudioMixer audioMixer;


    void Start()
    {
        fader.InFade(0f);

        //배경음 플레이
        AudioManager.Instance.PlayBgm("MainMenu");

        title1 = FindObjectOfType<Title1>();
    }


    public void Back()
    {
        AudioManager.Instance.Play("OptionButton");
        StartCoroutine(BackPlayScene());
    }


    IEnumerator BackPlayScene()
    {

        if (PlayerPrefs.GetString("previoudScene") != "1MainMenu")
        {
            fader.FadeTo();

            yield return new WaitForSeconds(1f);

            title1.ClickLoad();
        }
        else
        {
            fader.FadeTo(loadToScene);
        }

    }



    public void QuitGame()
    {
        AudioManager.Instance.Play("OptionButton");
        StartCoroutine(OutHere());
    }


    public void GoToMenu()
    {
        AudioManager.Instance.Play("OptionButton");
        fader.FadeTo(loadToScene);
    }
    

    IEnumerator OutHere()
    {
        fader.FadeTo();

        yield return new WaitForSeconds(1f);

        Debug.Log("Quit Game");
        Application.Quit();
    }







}
