using UnityEngine;
using UnityEngine.Audio;

// Audio 속성 데이터를 관리하는 직렬화된 클래스 
[System.Serializable] 
public class Sound 
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)] public float volume;
    [Range(0.1f, 3f)] public float pitch;
    public bool loop;

    [HideInInspector] //인스펙터에서 보이지 않음
    public AudioSource source;

}
