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
    private string sfxName = "";

    public AudioMixer audioMixer;


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //
        AudioMixerGroup[] audioMixerGroups = audioMixer.FindMatchingGroups("Master");
        

        // ���� ��� ����
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


    private void Start()
    {
        if (PlayerPrefs.GetString("bgm") == "off")
        {
            audioMixer.SetFloat("BGM", -40f);
        }
        
        if(PlayerPrefs.GetString("sfx") == "off")
        {
            audioMixer.SetFloat("SFX", -40f);
        }
    }


    public void Play(string soundName)
    {
        // ����� �̸� üũ
        if (sfxName == soundName)
        {
            // ���� ȿ���� ����
            Stop(sfxName);
            
        }


        Sound sound = null;

        // ���� ��Ͽ��� ����
        foreach (var s in sounds)
        {
            if(s.name == soundName)
            {
                sound = s;
                sfxName = s.name;
                break;
            }
        }

        if(sound == null)
        {
            Debug.Log($"Cannot Find {soundName}");
            return;
        }
        
        // ã�� ������ AudioSource�� �÷���
        sound.source.Play();

    }


    // ���� ����
    public void Stop(string soundName)
    {
        
        
        Sound sound = null;

        // ���� ��Ͽ��� ����
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

        // ã�� ������ AudioSource�� ����
        sound.source.Stop();
    }


    public void PlayBgm(string soundName)
    {
        // ����� �̸� üũ
        if(bgmName == soundName)
        {
            return; // �̱��� ��ų��� ��� ���
        }

        // ���� ����� ����
        Stop(bgmName);
        
        // ����� �÷���
        Sound sound = null;

        // ���� ��Ͽ��� ����
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

        // ã�� ������ AudioSource�� �÷���
        sound.source.Play();

    }


    public void StopBgm()
    {
        // ���� ����� ����
        Stop(bgmName);

        bgmName = "";
    }


    //�Ͻ�����
    public void PauseBgm(string soundName)
    {

        // ����� �÷���
        Sound sound = null;

        // ���� ��Ͽ��� ����
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

        // ã�� ������ AudioSource�� �Ͻ�����
        sound.source.Pause();
    }


    public void UnPauseBgm(string soundName)
    {
        
        // ����� �÷���
        Sound sound = null;

        // ���� ��Ͽ��� ����
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

        // �Ͻ������ߴ� ������ AudioSource�� �ٽ� �÷���
        sound.source.UnPause();
    }
    

}

