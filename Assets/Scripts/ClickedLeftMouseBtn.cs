using System.Collections;
using UnityEngine;

public class ClickedLeftMouseBtn : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public GameObject enemy;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            StartCoroutine(HandleLeftClick());
        }
    }

    IEnumerator HandleLeftClick() {
        yield return new WaitForSeconds(2 * Time.fixedDeltaTime);
        if (enemy == null) {
            tutorialManager.MoveOnToNextTutSection();
        }
    }
}
