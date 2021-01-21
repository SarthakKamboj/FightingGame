using UnityEngine;

public class NotifyTutWhenPopwerUpHit : MonoBehaviour
{
    public TutorialManager tutorialManager;

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            tutorialManager.MoveOnToNextTutSection();
        }
    }
}
