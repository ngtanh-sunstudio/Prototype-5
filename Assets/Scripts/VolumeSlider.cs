using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [Range(0f, 1f)] [SerializeField] private float startingVolume = 0.25f;

    public static event Action<float> VolumeChanged;

    void Awake()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void Start()
    {
        volumeSlider.SetValueWithoutNotify(startingVolume);
        VolumeChanged?.Invoke(startingVolume);
    }

    void OnDisable()
    {
        volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        VolumeChanged?.Invoke(volume);
    }
}
