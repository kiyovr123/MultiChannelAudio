using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TrackElement : MonoBehaviour
{

    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Text title;
    [SerializeField]
    private Slider volume;

    private float totalVolume;
    private string titleName;

    private void Update()
    {
        totalVolume = volume.value;
    }

    public float GetSliderValue()
    {
        return totalVolume;
    }

    public void SetTitleText(string name)
    {
        title.text = titleName.ToString();
    }
    [SerializeField]
    private string path= "file://C:/IMAGE";
    [SerializeField]
    private string[] fs;


    public void AddNewClip()
    {
        //finder を開いてclipのpathを取得して保存しておく
        fs = System.IO.Directory.GetFiles(path,"*",System.IO.SearchOption.AllDirectories);
    }

    public void PlayAudioClip()
    {
        Debug.Log("Play Audio Clip");
    }
    //指定したpathのフォルダのitemのpathを取得したい


}
