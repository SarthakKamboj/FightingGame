using System.Collections;
using UnityEngine;

public class DoubleClickedSpaceBar : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public Rigidbody playerMeshRb;
    int numTimesClickedSpace = 0;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(HandleJumpClick());
        }

        if (numTimesClickedSpace == 2) {
            tutorialManager.MoveOnToNextTutSection();
        }

    }

    IEnumerator HandleJumpClick() {
        yield return new WaitForSeconds(Time.fixedDeltaTime * 2);
        if (playerMeshRb.velocity.y != 0) {
            numTimesClickedSpace += 1;
        } else {
            numTimesClickedSpace = 0;
        }
    }

    
}
