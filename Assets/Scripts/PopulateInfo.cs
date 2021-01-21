using UnityEngine;
using TMPro;
using System.Collections;

public class PopulateInfo : MonoBehaviour
{
    public TextMeshProUGUI killCount, healthLeft, timeLeft;
    
    void Start() {
        StartCoroutine(Populate());
    }

    IEnumerator Populate() {
        yield return new WaitForSeconds(2 * Time.fixedDeltaTime);
        TextMeshProUGUI prevKillText = GameObject.FindWithTag("KillCount").GetComponent<TextMeshProUGUI>();
        killCount.text = prevKillText.text;

        TextMeshProUGUI prevTimeText = GameObject.FindWithTag("TimeLeft").GetComponent<TextMeshProUGUI>();
        timeLeft.text = prevTimeText.text;
    }

}
