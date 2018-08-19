using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAudioMixer : MonoBehaviour
{

    [SerializeField]
    private GameObject trackPrefab;
    [SerializeField]
    private PointerController pointer;
    private MultiAudioTrack multiAudioTrack;

    // Use this for initialization
    void Start()
    {
        AddTrack();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateAudioVolume();
    }

    public void AddTrack()
    {
        var obj = Instantiate(trackPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        obj.transform.parent = this.transform;
        multiAudioTrack = obj.GetComponent<MultiAudioTrack>();
    }

    public void CalculateAudioVolume()
    {
        float aVol = pointer.GetMouseYPos() * (1 - pointer.GetMouseXPos());
        multiAudioTrack.ChangePerChannelVolume(1, aVol);

        float bVol = pointer.GetMouseYPos() * pointer.GetMouseXPos();
        multiAudioTrack.ChangePerChannelVolume(0, bVol);
    }

}
