using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : SingletonMonoBehaviour<TrackManager>
{
    [SerializeField]
    private GameObject _TrackPrefab;
    [SerializeField]
    private List<Track> _TrackList;
    [SerializeField]
    private Track _CurrentTrack;
    [SerializeField]
    private Transform _TrackParents;
    [SerializeField]
    private GameObject _Finder;

    //clipのパス
    [SerializeField]
    private string _FolderPath = "D:/UnityProject/Multi/TrackList";

    public void ActiveFiner()
    {
        _Finder.SetActive(true);
    }

    public void CloseFinder()
    {
        _Finder.SetActive(false);
    }

    public string GetFolderPath()
    {
        return _FolderPath;
    }

    public Track CurrentTrack
    {
        set { _CurrentTrack = value; }
        get { return _CurrentTrack; }
    }

    private void Start()
    {
        // InitNewTrack();
    }

    /// <summary>
    /// 新しいtrack contentを生成する
    /// </summary>
    public void InitNewTrack()
    {
        var obj = Instantiate(_TrackPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        obj.transform.parent = _TrackParents;
        var track = obj.GetComponent<Track>();
        _TrackList.Add(track);
    }

    public void AddTrackList(Track track)
    {
        _TrackList.Add(track);
    }

    /// <summary>
    /// 現在選択されているtrackを再生するボタン
    /// </summary>
    public void PlayCurrentTrack()
    {
        if (_CurrentTrack != null)
        {
            _CurrentTrack.PlayAllAudioSources();
        }
    }

    /// <summary>
    /// 現在選択されているtrackを停止するボタン
    /// </summary>
    public void StopCurrentTrack()
    {
        if (_CurrentTrack != null)
        {
            _CurrentTrack.StopAllAudioSources();
        }
    }

    /// <summary>
    /// 
    //指定したclipの音量をpoiunterの位置を参照して変える
    /// </summary>
    public void CalculateAudioVolume(int trackIndex)
    {
        //float aVol = pointer.GetMouseYPos() * (1 - pointer.GetMouseXPos());
        //trackList[trackIndex].ChangePerChannelVolume(1, aVol);
        //float bVol = pointer.GetMouseYPos() * pointer.GetMouseXPos();
        //trackList[trackIndex].ChangePerChannelVolume(0, bVol);
        //SPeaker c.dの音量もここで変更する必要あり
    }

    //[SerializeField]
    //private GameObject trackPrefab;
    //[SerializeField]
    //private PointerController pointer;
    //[SerializeField]
    //private List<Track> trackList;

    //private Track multiAudioTrack;

    //// Use this for initialization
    //void Awake()
    //{
    //    CreateTrack();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //一旦0番目のiondexのみを与えておく、後で変更する必要がある
    //    CalculateAudioVolume(0);

    //}

    //public void CreateTrack()
    //{
    //    //track生成時にaudio clipを指定する
    //    var obj = Instantiate(trackPrefab, Vector3.zero, Quaternion.identity) as GameObject;
    //    obj.transform.parent = this.transform;
    //    var track = obj.GetComponent<Track>();
    //    trackList.Add(track);
    //}

    ////どのMultiTrackなのか知ってる必要がある
    //public void CalculateAudioVolume(int trackIndex)
    //{
    //    float aVol = pointer.GetMouseYPos() * (1 - pointer.GetMouseXPos());
    //    trackList[trackIndex].ChangePerChannelVolume(1, aVol);
    //    float bVol = pointer.GetMouseYPos() * pointer.GetMouseXPos();
    //    trackList[trackIndex].ChangePerChannelVolume(0, bVol);
    //    //SPeaker c.dの音量もここで変更する必要あり
    //}
}

//volumeの調整は、ointerの位置のみで判断するようにする

//TODO Trackの追加をできるようにする
//pointer の挙動

//問題点　なり始めるタイミングがばらばらになってしまう