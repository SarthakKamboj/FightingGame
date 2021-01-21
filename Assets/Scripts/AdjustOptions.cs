using UnityEngine;
using UnityEngine.Audio;

public class AdjustOptions : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetGraphics(int graphics) {
        QualitySettings.SetQualityLevel(graphics);
    }
}
