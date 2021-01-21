using System.Collections;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public float waitTime = 2f;
    bool waiting = true;

    void Start() {
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(waitTime);
        waiting = false;
    }


    void Update() {
        if (Input.anyKeyDown && !waiting) {
            tutorialManager.MoveOnToNextTutSection();
        }
    }
}
