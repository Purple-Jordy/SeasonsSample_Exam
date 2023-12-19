using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager instance;
    public static AudioManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    public Sound[] sounds;
    private string bgmName = "";

    public AudioMixer audioMixer;


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);

        //
        AudioMixerGroup[] audioMixerGroups = audioMixer.FindMatchingGroups("Master");
        
        // 사운드 목록 셋팅
        foreach(var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
        
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.playOnAwake = false;

            if(s.source.loop == true)
            {
                s.source.outputAudioMixerGroup = audioMixerGroups[1]; //bgm
            }
            else
            {
                s.source.outputAudioMixerGroup = audioMixerGroups[2]; //sfx
            }
            

        }
    }


    public void Play(string soundName)
    {
        Sound sound = null;

        // 사운드 목록에서 지정
        foreach (var s in sounds)
        {
            if(s.name == soundName)
            {
                sound = s;
                break;
            }
        }

        if(sound == null)
        {
            Debug.Log($"Cannot Find {soundName}");
            return;
        }
        
        // 찾은 사운드의 AudioSource를 플레이
        sound.source.Play();

    }


    // 사운드 정지
    public void Stop(string soundName)
    {
        Sound sound = null;

        // 사운드 목록에서 지정
        foreach (var s in sounds)
        {
            if (s.name == soundName)
            {
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            Debug.Log($"Cannot Find {soundName}");
            return;
        }

        // 찾은 사운드의 AudioSource를 정지
        sound.source.Stop();
    }


    public void PlayBgm(string soundName)
    {
        // 배경음 이름 체크
        if(bgmName == soundName)
        {
            return; // 싱글톤 시킬경우 계속 재생
        }

        // 이전 배경음 정지
        Stop(bgmName);
        
        // 배경음 플레이
        Sound sound = null;

        // 사운드 목록에서 지정
        foreach (var s in sounds)
        {
            if (s.name == soundName)
            {
                sound = s;
                bgmName = s.name;
                break;
            }
        }

        if (sound == null)
        {
            Debug.Log($"Cannot Find {soundName}");
            return;
        }

        // 찾은 사운드의 AudioSource를 플레이
        sound.source.Play();

    }


    public void StopBgm()
    {
        // 이전 배경음 정지
        Stop(bgmName);

        bgmName = "";
    }

}

