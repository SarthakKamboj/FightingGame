using UnityEngine;
using UnityEngine.UI;

public class PauseAndResumeGame : MonoBehaviour
{
    public GameObject pausePanel;
    public static bool GameIsPaused = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            HandlePausingOrResuming();
        }
    }

    void HandlePausingOrResuming() {
        if (GameIsPaused) {
            Resume();
        } else {
            Pause();
        }
    }

    void Pause() {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
