using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class bgmUI : MonoBehaviour
{
    public GameObject bgmOn;
    public GameObject bgmOff;
    public AudioMixer audioMixer;

    private void Start()
    {
        if(PlayerPrefs.GetString("bgm") == "off")
        {
            bgmOff.SetActive(true);
            bgmOn.SetActive(false);
        }
        else if(PlayerPrefs.GetString("bgm") == "on")
        {
            bgmOn.SetActive(true);
            bgmOff.SetActive(false);
        }   
    }


    public void BgmOff()
    {
        AudioManager.Instance.Play("OptionButton");
        audioMixer.SetFloat("BGM", -40f);
        bgmOff.SetActive(true);
        bgmOn.SetActive(false);
        PlayerPrefs.SetString("bgm", "off");
    }


    public void BgmOn()
    {
        AudioManager.Instance.Play("OptionButton");
        audioMixer.SetFloat("BGM", 0.6f);
        bgmOn.SetActive(true);
        bgmOff.SetActive(false);
        PlayerPrefs.SetString("bgm", "on");
    }

}
