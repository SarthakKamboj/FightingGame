using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    void Start() {
        Debug.Log(GameObject.Find("KillCount").name);
    }

    public void LoadNextLevel() {
        int nextLevelIdx = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIdx != SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(nextLevelIdx);
        }
    }
    
    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Quit() {
        Application.Quit();
    }

    public void GameOver() {
        LoadNextLevel();
    }
}
