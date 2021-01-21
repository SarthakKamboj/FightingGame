using UnityEngine;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    List<Transform> tutorialSections = new List<Transform>();
    int tutIdx = 0;

    void Start() {
        bool firstRound = true;
        foreach (Transform tutSection in transform) {
            if (firstRound) {
                if (!tutSection.gameObject.activeSelf) {
                    tutSection.gameObject.SetActive(true);
                }
                firstRound = false;
            } else {
                if (tutSection.gameObject.activeSelf) {
                    tutSection.gameObject.SetActive(false);
                }
            }
            tutorialSections.Add(tutSection);
        }
    }

    public void MoveOnToNextTutSection() {
        tutorialSections[tutIdx].gameObject.SetActive(false);
        Debug.Log(tutorialSections[tutIdx].name + " has been disabled");
        tutIdx += 1;
        if (tutIdx < tutorialSections.Count) {
            tutorialSections[tutIdx].gameObject.SetActive(true);
        } else {
            Debug.Log("finished tutorial");
        }
    }
    
}
