using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [HideInInspector]
    public int health;
    public HealthBar healthBar;

    [SerializeField]
    int minHealth = 0;

    [SerializeField]
    int maxHealth = 100;
    public GameObject gameManager;
    public SaveInfo saveInfo;
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
            saveInfo.SaveVals();
            gameManager.GetComponent<SceneHandler>().GameOver();
        }
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
