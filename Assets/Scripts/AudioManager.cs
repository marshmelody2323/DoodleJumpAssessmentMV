using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string volumeParameter = "Volume";

    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = -80;
        slider.maxValue = 20;
        slider.value = PlayerPrefs.GetFloat(volumeParameter, 0);

        mixer.SetFloat(volumeParameter, slider.value);
    }

    public void OnSliderValueChanged(float _newValue)
    {
        PlayerPrefs.SetFloat(volumeParameter, _newValue);
        PlayerPrefs.Save();

        mixer.SetFloat(volumeParameter, _newValue);
    }
}
