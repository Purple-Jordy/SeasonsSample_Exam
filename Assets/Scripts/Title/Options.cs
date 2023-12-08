using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public SceneFader fader;

    private Title1 title1;

    //[SerializeField]
    //private string loadToScene = "1MainMenu";

    void Start()
    {
        fader.InFade(0f);
        title1 = FindObjectOfType<Title1>();
    }

    public void Back()
    {
        //this.gameObject.SetActive(false);
        //fader.FadeTo(loadToScene);
        title1.ClickLoad();
    }



}
