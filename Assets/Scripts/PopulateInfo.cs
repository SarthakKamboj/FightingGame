using UnityEngine;
using TMPro;
using System.Collections;

public class PopulateInfo : MonoBehaviour
{
    [SerializeField]
    private InfoSection[] infoSections;
    
    void Start() {
        Populate();
    }

    void Populate() {
        foreach (InfoSection infoSection in infoSections) {

            if (infoSection.dataType == InfoSection.DataType.Float) {
                float f = PlayerPrefs.GetFloat(infoSection.key);
                infoSection.textMesh.text = f.ToString();
            } else if (infoSection.dataType == InfoSection.DataType.Int) {
                int i = PlayerPrefs.GetInt(infoSection.key);
                infoSection.textMesh.text = i.ToString();
            } else if (infoSection.dataType == InfoSection.DataType.String) {
                string s = PlayerPrefs.GetString(infoSection.key);
                infoSection.textMesh.text = s;
            }

        }
        
    }

}

[System.Serializable]
class InfoSection {
    public enum DataType {
        Int, Float, String
    };

    public string key;
    public DataType dataType;
    public TextMeshProUGUI textMesh;
}
