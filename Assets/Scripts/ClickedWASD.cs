using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedWASD : MonoBehaviour
{

    public TutorialManager tutorialManager;
    
    public Image w, a, s, d;
    bool clickedW = false, clickedS = false, clickedA = false, clickedD = false;
    public float clickOffset = 15f;

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            clickedW = true;
            Vector3 wAnchor = w.rectTransform.anchoredPosition3D;
            wAnchor.y += clickOffset;
            w.rectTransform.anchoredPosition3D = wAnchor;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            clickedA = true;
            Vector3 aAnchor = a.rectTransform.anchoredPosition3D;
            aAnchor.x -= clickOffset;
            a.rectTransform.anchoredPosition3D = aAnchor;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            clickedS = true;
            Vector3 sAnchor = s.rectTransform.anchoredPosition3D;
            sAnchor.y -= clickOffset;
            s.rectTransform.anchoredPosition3D = sAnchor;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            clickedD = true;
            Vector3 dAnchor = d.rectTransform.anchoredPosition3D;
            dAnchor.x += clickOffset;
            d.rectTransform.anchoredPosition3D = dAnchor;
 
        }

        if (DoneClickingWASD()) {
            tutorialManager.MoveOnToNextTutSection();
        }
    }

    bool DoneClickingWASD() {
        return clickedA && clickedD && clickedS && clickedW;
    }

}
