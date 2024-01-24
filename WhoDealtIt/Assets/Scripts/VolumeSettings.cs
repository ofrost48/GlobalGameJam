using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SfxSlider;

    public void SetMasterVol()
    {
        float volume = MasterSlider.value;
        volume = volume + 0.1f;
        myMixer.SetFloat("MasterVol", Mathf.Log10(volume)*80);
    }

    public void SetSfxVol()
    {
        float volume = SfxSlider.value;
        volume = volume + 0.1f;
        myMixer.SetFloat("SfxVol", Mathf.Log10(volume) * 80);
    }

    public void SetMusicVol()
    {
        float volume = MusicSlider.value;
        volume = volume + 0.1f;
        myMixer.SetFloat("MusicVol", Mathf.Log10(volume) * 80);
    }

    private void Start()
    {
        SetMasterVol();
        SetMusicVol();
        SetSfxVol();
    }
}
