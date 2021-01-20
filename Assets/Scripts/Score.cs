using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float score = 10000;
    public TextMeshProUGUI scoreNumText;
    [HideInInspector]
    public int scoreDecreaseMultiplier = 1;
    
    void Update()
    {
        scoreNumText.text = ((int) score).ToString();
        score -= Time.deltaTime * scoreDecreaseMultiplier;
    }
}
