using UnityEngine;

public class ClickedLeftMouseBtn : MonoBehaviour
{
    public TutorialManager tutorialManager;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            tutorialManager.MoveOnToNextTutSection();
        }
    }
}
