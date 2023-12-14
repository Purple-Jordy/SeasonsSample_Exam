using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SelectSpring : MonoBehaviour
{
    public SceneFader fader;



    void Start()
    {
        fader.InFade(0.3f);

        //배경음 플레이
        AudioManager.Instance.PlayBgm("selectScene");
        
    }


    public void Options()
    {
        PlayerPrefs.SetString("previoudScene", "2SelectSpring");
        fader.FadeTo("1Options");
    }

}
