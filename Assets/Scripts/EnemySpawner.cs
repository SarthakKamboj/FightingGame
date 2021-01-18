using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numEnemies = 10;
    public GameObject ground;
    public float spawnAreaPadding = 2f;
    public Transform randomTransform;
    float minX, maxX, minY, maxY, minZ, maxZ;

    void Start() {
        GameObject tempEnemy = Instantiate(enemyPrefab, randomTransform.position, Quaternion.Euler(Vector3.up));
        Vector3 enemyExtents = tempEnemy.GetComponent<Collider>().bounds.extents;
        minX = ground.transform.Find("WallLeft").transform.position.x + enemyExtents.x + spawnAreaPadding;
        maxX = ground.transform.Find("WallRight").transform.position.x - enemyExtents.x - spawnAreaPadding;
        minY = ground.transform.Find("Ceiling").transform.position.y + enemyExtents.y + spawnAreaPadding;
        maxY = ground.transform.Find("Floor").transform.position.y - enemyExtents.y - spawnAreaPadding;
        minZ = ground.transform.Find("WallBack").transform.position.z + enemyExtents.z + spawnAreaPadding;
        maxZ = ground.transform.Find("WallFront").transform.position.z - enemyExtents.z - spawnAreaPadding;

        while (numEnemies > 0) {
            Vector3 randomSpawnPoint = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.Euler(Vector3.up));
            numEnemies -= 1;
        }
    } 
}
