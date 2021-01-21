using UnityEngine;
using TMPro;
using System.Collections;

public class PopulateInfo : MonoBehaviour
{
    [SerializeField]
    private InfoSection[] infoSections;
    
    void Start() {
        // StartCoroutine(Populate());
        Populate();
    }

    void Populate() {
        foreach (InfoSection infoSection in infoSections) {
            int defaultNum = -1;

            float f = PlayerPrefs.GetFloat(infoSection.key, (float) defaultNum);
            if (f != (float) defaultNum) {
                infoSection.textMesh.text = f.ToString();
                return;
            }

            int i = PlayerPrefs.GetInt(infoSection.key, defaultNum);
            if (i != defaultNum) {
                infoSection.textMesh.text = i.ToString();
                return;
            }

            string defaultString = "foo";
            string s = PlayerPrefs.GetString(infoSection.key, defaultString);
            if (s != defaultString) {
                infoSection.textMesh.text = s;
                return;
            }

        }
        
    }

}

[System.Serializable]
class InfoSection {
    public string key;
    public TextMeshProUGUI textMesh;
}
