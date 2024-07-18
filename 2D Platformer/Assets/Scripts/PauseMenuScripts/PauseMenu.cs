using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);

    [SerializeField] private AudioMixerGroup _mixer;

    public bool Enabled { get; private set; } = false;

    private void OnEnable()
    {
        Time.timeScale = 0.0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }

    public void ToggleMusic()
    {
        if (Enabled)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, 0);
            Enabled = false;
        }
        else
        {
            _mixer.audioMixer.SetFloat(MasterVolume, -80);
            Enabled = true;
        }
    }
}
