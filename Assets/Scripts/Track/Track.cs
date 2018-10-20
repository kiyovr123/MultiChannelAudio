using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Audio;

public class Track : MonoBehaviour
{
    [SerializeField]
    private List<AudioSource> _AudioSourceList;
    [SerializeField]
    private AudioClip _SampleAudioClip;
    [SerializeField]
    private int _ChannelNumber;
    [SerializeField]
    private List<AudioClip> _AudioClipList;
    [SerializeField]
    private AudioMixerGroup _AudioMixer;
    [SerializeField]
    private Text _TrackTitle;
    [SerializeField]
    private Slider _Volume;
    [SerializeField]
    private Image[] _BackGroundSprite;
    [SerializeField]
    private Image[] _IconSprite;
    [SerializeField]
    private GameObject _ClipList;

    private DataPath _DataPath=new DataPath();

    private AudioClip _CurrentAudioClip;
    private bool _IsActive;
    [SerializeField]
    private string[] _TempAllPath;

    private string _SelectClipPath;

    //audioclipの選択システムが必要
    //pathを指定してそれを再生させる

    public Text TrackTitle
    {
        set { _TrackTitle = value; }
        get { return _TrackTitle; }
    }

    /// <summary>
    ///生成されたタイミングでaudioSourceを複数作成する
    /// </summary>
    private void Start()
    {
        TrackManager.Instance.AddTrackList(this);
        AddAudioSource();
        LoadAudioClipByPath();
    }

    public void LoadAudioClipByPath()
    {
        var path = "D:/UnityProject/Multi/TrackList";
        _TempAllPath = Directory.GetFiles(path, "*.wav");
    }

    public IEnumerator StreamAudioClip()
    {
        using (WWW www = new WWW(_SelectClipPath))
        {
            yield return www;
            _CurrentAudioClip = www.GetAudioClip(false,true);
        }
    }

    /// <summary>
    /// AudioSourceを使用する分追加する
    /// </summary>
    public void AddAudioSource()
    {
        for (int i = 0; i < _ChannelNumber; i++)
        {
            this.gameObject.AddComponent<AudioSource>();
        }

        AudioSource[] tempAudio = GetComponents<AudioSource>();

        for (int i = 0; i < tempAudio.Length; i++)
        {
            _AudioSourceList.Add(tempAudio[i]);
            _AudioSourceList[i].playOnAwake = false;
            _AudioSourceList[i].loop = true;
            // _AudioSourceList[i].outputAudioMixerGroup = mixer;
        }
    }

    /// <summary>
    /// 四チャンネル用のaudioclipを生成する
    /// </summary>
    /// <param name="clip"></param>
    public void CreateAudioClip(AudioClip clip)
    {
        _AudioClipList.Clear();

        for (int i = 0; i < _ChannelNumber; i++)
        {
            int targetChannel = i + 1;
            var multiClip = AudioClipExtensions.CreateSpeakerSpecificClip(_SampleAudioClip, _ChannelNumber, targetChannel);
            _AudioClipList.Add(multiClip);
            _AudioSourceList[i].clip = _AudioClipList[i];
        }
    }

    /// <summary>
    /// AudioSourceを同時に再生する
    /// </summary>
    public void PlayAllAudioSources()
    {
        for (int i = 0; i < _AudioSourceList.Count; i++)
        {
            _AudioSourceList[i].Play();
        }
    }

    /// <summary>
    /// trackのオーディオの停止
    /// </summary>
    /// <param name="clip"></param>
    public void StopAllAudioSources()
    {
        for (int i = 0; i < _AudioSourceList.Count; i++)
        {
            _AudioSourceList[i].Stop();
        }
    }

    /// <summary>
    /// それぞれのチャンネルのvolumeを変える,TrackManagerから指定されたtrackのvolumeを変更する
    ///
    /// </summary>
    /// <param name="num"></param>
    /// <param name="vol"></param>
    public void ChangePerChannelVolume(int num, float vol)
    {
        _AudioSourceList[num].volume = vol;
    }


    //[SerializeField]
    //private List<AudioSource> audioSourceList;
    //[SerializeField]
    //private AudioClip defaultAudioClip;
    //[SerializeField]
    //private int channel = 2;
    //[SerializeField]
    //private List<AudioClip> multiChannelTrackList;
    //[SerializeField]
    //private AudioMixerGroup mixer;

    //private void Start()
    //{
    //    InitAudioSouce(channel);
    //    //addされたタイミングで使えるclipをすべて参照持ってる必要がある
    //    PlayTrackSound();
    //}

    //public void InitAudioSouce(int count)
    //{
    //    for (int i = 0; i < count; i++)
    //    {
    //        this.gameObject.AddComponent<AudioSource>();
    //    }

    //    AudioSource[] tempAudio = GetComponents<AudioSource>();

    //    for (int i = 0; i < tempAudio.Length; i++)
    //    {
    //        audioSourceList.Add(tempAudio[i]);
    //        audioSourceList[i].playOnAwake = false;
    //        audioSourceList[i].loop = true;
    //       // audioSourceList[i].outputAudioMixerGroup = mixer;
    //    }

    //    CreateMultiAudioClip();

    //}

    ////生成に引数でclipを与える
    //public void CreateMultiAudioClip()
    //{
    //    for (int i = 0; i < channel; i++)
    //    {
    //        int targetChannel = i + 1;
    //        //チャンネル数の実装はあとで考ええる
    //        var clip = AudioClipExtensions.CreateSpeakerSpecificClip(defaultAudioClip, 2, targetChannel);
    //        multiChannelTrackList.Add(clip);
    //        audioSourceList[i].clip = multiChannelTrackList[i];
    //    }
    //}

    //public void PlayTrackSound()
    //{
    //    for (int i = 0; i < channel; i++)
    //    {
    //        audioSourceList[i].Play();
    //    }
    //}

    //public void ChangePerChannelVolume(int num, float vol)
    //{
    //    audioSourceList[num].volume = vol;
    //}

    //public void SetTrackVolume(float vol)
    //{
    //    for (int i = 0; i < channel; i++)
    //    {
    //        audioSourceList[i].volume = vol;
    //    }
    //}

    //public void SetDefaultAudioClip(AudioClip clip)
    //{
    //    defaultAudioClip = clip;
    //}
    //[SerializeField]
    //private Button playButton;
    //[SerializeField]
    //private Text title;
    //[SerializeField]
    //private Slider volume;
    //[SerializeField]
    //private string path = "file://C:/IMAGE";
    //[SerializeField]
    //private string[] fs;

    //private float totalVolume;
    //private string titleName;

    //private void Update()
    //{
    //    totalVolume = volume.value;
    //}

    //public float GetSliderValue()
    //{
    //    return totalVolume;
    //}

    //public void SetTitleText(string name)
    //{
    //    title.text = titleName.ToString();
    //}

    //public void AddNewClip()
    //{
    //    //finder を開いてclipのpathを取得して保存しておく
    //    fs = System.IO.Directory.GetFiles(path,"*",System.IO.SearchOption.AllDirectories);
    //}

    //public void PlayAudioClip()
    //{
    //    Debug.Log("Play Audio Clip");
    //}
    ////指定したpathのフォルダのitemのpathを取得したい
}
