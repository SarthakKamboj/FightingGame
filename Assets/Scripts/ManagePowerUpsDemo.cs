using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePowerUpsDemo : MonoBehaviour
{
    public GameObject powerUps;
    void Awake() {
        powerUps.SetActive(false);
        gameObject.SetActive(false);
    }

    void OnEnable() {
        powerUps.SetActive(true);
        Debug.Log("enabled");
    }
}
