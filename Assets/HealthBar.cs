using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthSliderImage;
    public Gradient gradient;
    public Slider healthSlider;

    public void UpdateHealthBar(float value) {
        healthSlider.value = value;
        healthSliderImage.color = gradient.Evaluate(value);
    }

}
