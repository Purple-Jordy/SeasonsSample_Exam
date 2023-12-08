using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public SceneFader fader;

    [SerializeField]
    private string loadToScene = "MainMenu";


    void Start()
    {
        fader.InFade(0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        fader.FadeTo(loadToScene);
    }

    public void Options()
    {
        fader.FadeTo("1Options");
    }

}
