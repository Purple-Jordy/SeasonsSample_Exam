using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSpring : MonoBehaviour
{
    public SceneFader fader;

    void Start()
    {
        fader.InFade(0.3f);
    }

    public void Options()
    {
        PlayerPrefs.SetString("previoudScene", "2SelectSpring");
        fader.FadeTo("1Options");
    }

}
