﻿using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [HideInInspector]
    private int health;
    public HealthBar healthBar;

    [SerializeField]
    int minHealth = 0;

    [SerializeField]
    int maxHealth = 100;
    public GameObject gameManager;
    void Start()
    {
        health = maxHealth;
        UpdateHealthBar();
    }

    public void IncreaseHealth(int amount) {
        health = Mathf.Clamp(health + amount, minHealth, maxHealth);
        UpdateHealthBar();
    }

    public void TakeDamage(int amount) {
        health = Mathf.Clamp(health - amount, minHealth, maxHealth);
        UpdateHealthBar();
        if (health <= 0) {
            gameManager.GetComponent<SceneHandler>().GameOver();
        }
    }

    void OnDestroy() {
        PlayerPrefs.SetInt("HealthLeft",health);
    }


    void UpdateHealthBar()
    {
        healthBar.UpdateHealthBar(health / (float) maxHealth);
    }

    

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "HealthPowerUp") {
            int increase = collider.gameObject.GetComponent<HealthPowerUp>().healthIncrease;
            IncreaseHealth(increase);
        }
    }

    
}
