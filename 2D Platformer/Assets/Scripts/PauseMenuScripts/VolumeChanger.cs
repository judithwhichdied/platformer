using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    [SerializeField] AudioMixerGroup _mixer;
    [SerializeField] PauseMenu _volumeMute;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeVolume(string volumeName)
    {
        if (_volumeMute.Enabled == false)
        {
            float volumeLevel = _slider.value;

            _mixer.audioMixer.SetFloat(volumeName, Mathf.Log10(volumeLevel) * 20);
        }
    }
}