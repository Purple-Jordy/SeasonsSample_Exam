using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sfxUI : MonoBehaviour
{
    public GameObject sfxOn;
    public GameObject sfxOff;
    public AudioMixer audioMixer;


    public void SfxOff()
    {
        AudioManager.Instance.Play("OptionButton");
        audioMixer.SetFloat("SFX", -40f);
        sfxOff.SetActive(true);
        sfxOn.SetActive(false);
    }


    public void SfxOn()
    {
        audioMixer.SetFloat("SFX", 15f);
        AudioManager.Instance.Play("OptionButton");
        sfxOn.SetActive(true);
        sfxOff.SetActive(false);
    }
}
