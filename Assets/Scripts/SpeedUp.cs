using System.Collections;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public Rigidbody playerRb;
    public float powerUpDuration = 10f;
    bool spedUp = false;

    void FixedUpdate() {
        HandleCollisionDetection();
    }

    void HandleCollisionDetection() {
        if (!spedUp && playerRb.velocity.magnitude <= playerMovement.maxVelocity) {
            playerRb.collisionDetectionMode = CollisionDetectionMode.Discrete;
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "SpeedPowerUp") {
            HandleSpeedPowerUp(collider.gameObject);
        }
    }

    void HandleSpeedPowerUp(GameObject go) {
        spedUp = true;
        float speedMultiplier = go.GetComponent<SpeedUpPowerUp>().speedMultiplier;
        playerMovement.maxVelocity *= speedMultiplier;
        playerMovement.forceMultipler *= speedMultiplier;
        playerRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        StartCoroutine(RemoveSpeedUp(speedMultiplier));
    }

    IEnumerator RemoveSpeedUp(float speedMultiplier) {
        yield return new WaitForSeconds(powerUpDuration);
        playerMovement.maxVelocity *= 1/speedMultiplier;
        playerMovement.forceMultipler *= 1/speedMultiplier;
        spedUp = false;
    }

    void HealthPowerUp() {
        Debug.Log("hit health");
    }
}
