using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public SceneFader fader;

    private Title1 title1;

    [SerializeField]
    private string loadToScene = "1MainMenu";


    void Start()
    {
        fader.InFade(0.3f);
        title1 = FindObjectOfType<Title1>();
    }


    public void Back()
    {
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
        StartCoroutine(OutHere());
    }


    public void GoToMenu()
    {
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
