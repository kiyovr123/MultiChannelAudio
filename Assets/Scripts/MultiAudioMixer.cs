using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAudioMixer : MonoBehaviour
{

    [SerializeField]
    private GameObject trackPrefab;
    [SerializeField]
    private PointerController pointer;
    [SerializeField]
    private List<MultiAudioTrack> multiTrackList;

    private MultiAudioTrack multiAudioTrack;

    // Use this for initialization
    void Awake()
    {
        CreateTrack();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateAudioVolume();
    }

    public void CreateTrack()
    {
        //track生成時にaudio clipを指定する
        var obj = Instantiate(trackPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        obj.transform.parent = this.transform;
        var track = obj.GetComponent<MultiAudioTrack>();
        multiTrackList.Add(track);
    }

    //どのMultiTrackなのか知ってる必要がある
    //引数でトラックのindexを渡す
    public void CalculateAudioVolume()
    {
        float aVol = pointer.GetMouseYPos() * (1 - pointer.GetMouseXPos());
        multiTrackList[0].ChangePerChannelVolume(1, aVol);
        float bVol = pointer.GetMouseYPos() * pointer.GetMouseXPos();
        multiTrackList[0].ChangePerChannelVolume(0, bVol);
        //SPeaker c.dの音量もここで変更する必要あり
    }

}
//volumeの調整は、ointerの位置のみで判断するようにする

//TODO Trackの追加をできるようにする
//pointer の挙動

//問題点　なり始めるタイミングがばらばらになってしまう