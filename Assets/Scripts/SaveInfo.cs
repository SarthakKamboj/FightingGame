using UnityEngine;
using TMPro;

public class SaveInfo : MonoBehaviour
{
    // public TextMeshProUGUI textToSaveAsFloat;
    // public string key;
    
    // void OnDestroy() {
    //     PlayerPrefs.SetFloat(key,float.Parse(textToSaveAsFloat.text));
    // }

    public TextMeshProUGUI killCount, timeLeft;
    public Health health;

    public void SaveVals() {
        Debug.Log(int.Parse(killCount.text));
        Debug.Log(int.Parse(timeLeft.text));
        Debug.Log(health.health);
        PlayerPrefs.SetInt("KillCount", int.Parse(killCount.text));
        PlayerPrefs.SetInt("TimeLeft", int.Parse(timeLeft.text));
        PlayerPrefs.SetInt("HealthLeft", health.health);
    }
}


