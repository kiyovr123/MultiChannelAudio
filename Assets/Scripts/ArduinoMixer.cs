using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

using UnityEngine;

public class ArduinoMixer : MonoBehaviour
{

    //public SerialHandler serialHandler;
    //public AudioMixer mixer;
    //public int getMixerV;
    //[SerializeField]
    //private float myVolume;

    //// Use this for initialization
    //void Start()
    //{
    //    serialHandler.OnDataReceived += OnDataReceived;
    //}

    //void Updata()
    //{
    //    getMixerV = serialHandler.mixerValue;
    //    ConvertAudio();
    //    mixer.SetFloat("MixerVolume", myVolume);
    //}

    //private void ConvertAudio()
    //{
    //    getMixerV = serialHandler.mixerValue;
    //    var value = (float)getMixerV;
    //    myVolume = Mathf.InverseLerp(0f, 324f, value);
    //}

    ////受信した信号(message)に対する処理
    //void OnDataReceived(string message)
    //{
    //    var data = message.Split(new string[] { "\t" }, System.StringSplitOptions.None);

    //    if (data.Length < 2)
    //    {
    //        return;
    //    }

    //    try
    //    {
    //        Debug.Log("receive");
    //    }
    //    catch (System.Exception e)
    //    {
    //        Debug.LogWarning(e.Message);
    //    }
    //}
}
