using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAudioTrack : MonoBehaviour
{
    //[SerializeField]
    //private AudioClip defaultAudioClio;
    //[SerializeField]
    //private AudioSource secondAudio;

    //private AudioSource audioSource;
    //private AudioClip audioClip;
    //private AudioClip secondAudioClip;

    //private void Start()
    //{
    //    if (audioSource == null)
    //    {
    //        audioSource = GetComponent<AudioSource>();
    //    }
    //    audioClip = AudioClipExtensions.CreateSpeakerSpecificClip(defaultAudioClio, 2, 1);
    //    secondAudioClip = AudioClipExtensions.CreateSpeakerSpecificClip(defaultAudioClio, 2, 2);
    //    PlayAudio();
    //}

    //private void PlayAudio()
    //{
    //    audioSource.clip = audioClip;
    //    audioSource.Play();
    //    secondAudio.clip = secondAudioClip;
    //    secondAudio.Play();
    //}

    [SerializeField]
    private List<AudioSource> audioSourceList;
    [SerializeField]
    private AudioClip defaultAudioClip;
    



    

}
