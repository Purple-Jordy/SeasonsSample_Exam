using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class bgmUI : MonoBehaviour
{
    public GameObject bgmOn;
    public GameObject bgmOff;
    public AudioMixer audioMixer;


    public void BgmOff()
    {
        AudioManager.Instance.Play("OptionButton");
        audioMixer.SetFloat("BGM", -40f);
        bgmOff.SetActive(true);
        bgmOn.SetActive(false);
    }


    public void BgmOn()
    {
        AudioManager.Instance.Play("OptionButton");
        audioMixer.SetFloat("BGM", 0.6f);
        bgmOn.SetActive(true);
        bgmOff.SetActive(false);
    }

}
