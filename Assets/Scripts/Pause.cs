using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Time.timeScale == 0f) {
                Time.timeScale = 1f;
            } else {
                Time.timeScale = 0f;
            }
        }
    }
}
