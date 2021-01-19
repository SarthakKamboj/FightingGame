using UnityEngine;

public class HealthIncrease : MonoBehaviour
{
    public Health playerHealth;

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "HealthPowerUp") {
            int increase = collider.gameObject.GetComponent<HealthPowerUp>().healthIncrease;
            playerHealth.health = (int) Mathf.Clamp(playerHealth.health+increase, 0f, playerHealth.maxHealth);
            Destroy(collider.gameObject);
        }
    }
}
