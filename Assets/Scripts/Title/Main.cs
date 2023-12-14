using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Main : MonoBehaviour
{
    public SceneFader fader;

    [SerializeField]
    private string loadToScene = "MainMenu";

    public AudioMixer audioMixer;


    void Start()
    {
        fader.InFade(0.3f);

        //배경음 플레이
        AudioManager.Instance.PlayBgm("MainMenu");
    }


    void Update()
    {
        
    }


    public void Play()
    {
        fader.FadeTo(loadToScene);
    }


    public void Options()
    {
        PlayerPrefs.SetString("previoudScene", "1MainMenu");
        fader.FadeTo("1Options");
    }

}
