using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{


    public void LoadNextLevel() {
        int nextLevelIdx = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIdx == SceneManager.sceneCount) {
            SceneManager.LoadScene(nextLevelIdx);
        }
    }
    
    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
