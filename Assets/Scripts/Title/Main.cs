using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Main : MonoBehaviour
{
    public SceneFader fader;

    [SerializeField]
    private string loadToScene = "MainMenu";


    void Start()
    {
        fader.InFade(0f);

        //배경음 플레이
        AudioManager.Instance.PlayBgm("MainMenu");
    }


    public void Play()
    {
        AudioManager.Instance.Play("OptionButton");
        fader.FadeTo(loadToScene);
    }


    public void Options()
    {
        AudioManager.Instance.Play("OptionButton");
        PlayerPrefs.SetString("previoudScene", "1MainMenu");
        fader.FadeTo("1Options");
    }

}
