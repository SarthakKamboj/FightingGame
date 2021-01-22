using UnityEngine;
using TMPro;
using System.Collections;

public class HighScore : MonoBehaviour
{

    public TextMeshProUGUI killCountText;
    public GameObject highScoreUIGO;
    int highScore;

    void Start() {
        highScore = PlayerPrefs.GetInt("HighScore",0);
        StartCoroutine(CheckIfHighScore());
    }

    IEnumerator CheckIfHighScore() {
        yield return new WaitForSeconds(2 * Time.fixedDeltaTime);
        int curScore = int.Parse(killCountText.text);
        if (curScore > highScore) {
            highScoreUIGO.SetActive(true);
            PlayerPrefs.SetInt("HighScore", curScore);
        }
    }

}
