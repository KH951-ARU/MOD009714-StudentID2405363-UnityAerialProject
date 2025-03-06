using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioChatter : MonoBehaviour
{
    public AudioSource RadioChatterAudioSource;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("playChatter", Random.Range(5, 15),Random.Range(4, 8));
    }

    void playChatter()
    { RadioChatterAudioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
           RadioChatterAudioSource.Play();
    }
}
