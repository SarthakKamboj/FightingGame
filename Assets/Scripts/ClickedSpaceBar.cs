using UnityEngine;

public class ClickedSpaceBar : MonoBehaviour
{
    public TutorialManager tutorialManager;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            tutorialManager.MoveOnToNextTutSection();
        }
    }
}
