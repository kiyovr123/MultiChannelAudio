using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MultiAudioTrack : MonoBehaviour
{

    [SerializeField]
    private List<AudioSource> audioSourceList;
    [SerializeField]
    private AudioClip defaultAudioClip;
    [SerializeField]
    private int channel=2;
    [SerializeField]
    private List<AudioClip> multiChannelTrackList;
    [SerializeField]
    private AudioMixerGroup mixer;
    private void Start()
    {
        InitAudioSouce(channel);
        CreateMultiAudioClip();
        PlayTrackSound();
    }

    public void InitAudioSouce(int count)
    {
        for (int i = 0; i < count; i++)
        {
            this.gameObject.AddComponent<AudioSource>();
        }

        AudioSource[] tempAudio = GetComponents<AudioSource>();

        for (int i = 0; i < tempAudio.Length; i++)
        {
            audioSourceList.Add(tempAudio[i]);
            audioSourceList[i].playOnAwake = false;
            audioSourceList[i].loop = true;
            audioSourceList[i].outputAudioMixerGroup = mixer;

            
        }

    }

    public void CreateMultiAudioClip()
    {
        for (int i = 0; i < channel; i++)
        {
            int targetChannel = i + 1;
            //チャンネル数の実装はあとで考ええる
            var clip = AudioClipExtensions.CreateSpeakerSpecificClip(defaultAudioClip, 2, targetChannel);
            multiChannelTrackList.Add(clip);
            audioSourceList[i].clip = multiChannelTrackList[i];
        }
    }

    public void PlayTrackSound()
    {
        for (int i = 0; i < channel; i++)
        {
            audioSourceList[i].Play();
        }
    }

    public void ChangePerChannelVolume(int num, float vol)
    {
        audioSourceList[num].volume = vol;
    }

    public void SetTrackVolume(float vol)
    {
        for (int i = 0; i < channel; i++)
        {
            audioSourceList[i].volume = vol;
        }
    }

    public void SetDefaultAudioClip(AudioClip clip)
    {
        defaultAudioClip = clip;
    }

}
