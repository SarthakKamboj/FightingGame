using UnityEngine;
using TMPro;

public class SaveInfo : MonoBehaviour
{
    public TextMeshProUGUI textToSaveAsFloat;
    public string key;
    
    void OnDestroy() {
        PlayerPrefs.SetFloat(key,float.Parse(textToSaveAsFloat.text));
    }
    
}
