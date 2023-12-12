using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title : MonoBehaviour
{
    public SceneFader fader;
    [SerializeField]
    private string loadToScene = "1MainMenu";

    public TextMeshProUGUI text;
    private string m_text = "RUSTY  LAKE";

    void Start()
    {
        fader.InFade(0f);
        StartCoroutine(_typing());
    }


IEnumerator _typing()
    {
        yield return new WaitForSeconds(2f);

        for(int i = 0; i < m_text.Length; i++)
        {
            text.text = m_text.Substring(0, i+1);

            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(1f);

        fader.FadeTo(loadToScene);
    }
}