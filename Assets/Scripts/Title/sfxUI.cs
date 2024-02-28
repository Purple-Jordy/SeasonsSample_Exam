using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sfxUI : MonoBehaviour
{
    public GameObject sfxOn;
    public GameObject sfxOff;
    public AudioMixer audioMixer;


    private void Start()
    {
        if (PlayerPrefs.GetString("sfx") == "off")
        {
            sfxOff.SetActive(true);
            sfxOn.SetActive(false);
        }
        else if (PlayerPrefs.GetString("sfx") == "on")
        {
            sfxOn.SetActive(true);
            sfxOff.SetActive(false);
        }
    }


    public void SfxOff()
    {
        AudioManager.Instance.Play("OptionButton");
        audioMixer.SetFloat("SFX", -40f);
        sfxOff.SetActive(true);
        sfxOn.SetActive(false);
        PlayerPrefs.SetString("sfx", "off");
    }


    public void SfxOn()
    {
        audioMixer.SetFloat("SFX", 15f);
        AudioManager.Instance.Play("OptionButton");
        sfxOn.SetActive(true);
        sfxOff.SetActive(false);
        PlayerPrefs.SetString("sfx", "on");
    }
}
