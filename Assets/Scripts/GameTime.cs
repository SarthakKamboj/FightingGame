using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    public float time = 10000;
    public TextMeshProUGUI timeNumText;
    [HideInInspector]
    public int timeDecreaseMultiplier = 1;
    public SceneHandler sceneHandler;
    
    void Update()
    {
        timeNumText.text = ((int) time).ToString();
        time -= Time.deltaTime * timeDecreaseMultiplier;

        if (time <= 0f) {
            sceneHandler.GameOver();
        }
    }
}
