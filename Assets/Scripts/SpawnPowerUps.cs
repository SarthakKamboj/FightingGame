using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    [SerializeField]
    private List<PowerUpHandler> powerUpHandlers;

    [Tooltip("This must a GameObject containing all the spawn points")]
    public GameObject spawnPointsAvailable;
    [SerializeField]
    float timeBetweenPowerUps = 1f;
    [SerializeField]
    [Range(0,1)]
    float probOfSpawningPowerUp = 0.2f;
    List<ActivePowerUp> activePowerUps;
    List<Transform> unoccupiedSpawnPoints;
    float time = 0f;

    void Start() {
        unoccupiedSpawnPoints = new List<Transform>();
        activePowerUps = new List<ActivePowerUp>();

        foreach(Transform child in spawnPointsAvailable.transform) {
            unoccupiedSpawnPoints.Add(child);
        }
    }


    void CheckForDestroyedPowerUps() {
        foreach(ActivePowerUp activePowerUp in activePowerUps.ToArray()) {
            if (activePowerUp.powerUpGO == null) {
                unoccupiedSpawnPoints.Add(activePowerUp.spawnPoint);
                activePowerUp.powerUpHandler.curNumInstances -= 1;
                activePowerUps.Remove(activePowerUp);
            }
        }
    }

    void FixedUpdate() {

        CheckForDestroyedPowerUps();

        time += Time.fixedDeltaTime;
        if (time >= timeBetweenPowerUps) {
            time -= timeBetweenPowerUps;
            float rand = Random.Range(0f,1f);
            if (rand < probOfSpawningPowerUp) {
                int powerUpIdx = Random.Range(0, powerUpHandlers.Count);
                PowerUpHandler powerUpHandler = powerUpHandlers[powerUpIdx];

                if (powerUpHandler.curNumInstances < powerUpHandler.getMaxInstances()) {
                    SpawnPowerUp(powerUpHandler);
                }
            }
        }
    }

    void SpawnPowerUp(PowerUpHandler powerUpHandler) {
        int spawnPtIdx = Random.Range(0, unoccupiedSpawnPoints.Count);

        Transform spawnPoint = unoccupiedSpawnPoints[spawnPtIdx];
        GameObject powerUpGO = Instantiate(powerUpHandler.powerUpPrefab, spawnPoint.position, Quaternion.Euler(Vector3.up));

        unoccupiedSpawnPoints.Remove(spawnPoint);
        activePowerUps.Add(new ActivePowerUp(powerUpGO, spawnPoint, powerUpHandler));

        powerUpHandler.curNumInstances += 1;
        Debug.Log("spawned power up");
    }
}

[System.Serializable]
class PowerUpHandler {
    public GameObject powerUpPrefab;
    [SerializeField]
    int maxInstances;
    [HideInInspector]
    public int curNumInstances = 0;

    public int getMaxInstances() {
        return maxInstances;
    }
}

class ActivePowerUp {
    public GameObject powerUpGO;
    public Transform spawnPoint;
    public PowerUpHandler powerUpHandler;

    public ActivePowerUp(GameObject _powerUpGO, Transform _spawnPoint, PowerUpHandler _powerUpHandler) {
        this.spawnPoint = _spawnPoint;
        this.powerUpGO = _powerUpGO;
        this.powerUpHandler = _powerUpHandler;
    }
}