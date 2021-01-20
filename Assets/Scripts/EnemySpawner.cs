using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numEnemies = 10;
    public GameObject ground;
    public float spawnAreaPadding = 2f;
    // public Transform randomTransform;
    // float minX, maxX, minY, maxY, minZ, maxZ;

    void Start() {
        float minX = ground.transform.Find("WallLeft").transform.position.x;
        float minY = ground.transform.Find("Ceiling").transform.position.y;
        float minZ = ground.transform.Find("WallBack").transform.position.z;

        Vector3 randomPos = new Vector3(Random.Range(minX - 300f, minX - 2f),Random.Range(minY - 300f, minY - 2f),Random.Range(minZ - 300f, minZ - 2f));

        GameObject tempEnemy = Instantiate(enemyPrefab, randomPos, Quaternion.Euler(Vector3.up));
        Vector3 enemyExtents = tempEnemy.GetComponent<Collider>().bounds.extents;

        float minSpawnX = minX + enemyExtents.x + spawnAreaPadding;
        float maxSpawnX = ground.transform.Find("WallRight").transform.position.x - enemyExtents.x - spawnAreaPadding;
        float minSpawnY = minY + enemyExtents.y + spawnAreaPadding;
        float maxSpawnY = ground.transform.Find("Floor").transform.position.y - enemyExtents.y - spawnAreaPadding;
        float minSpawnZ = minZ + enemyExtents.z + spawnAreaPadding;
        float maxSpawnZ = ground.transform.Find("WallFront").transform.position.z - enemyExtents.z - spawnAreaPadding;

        while (numEnemies > 0) {
            Vector3 randomSpawnPoint = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), Random.Range(minSpawnZ, maxSpawnZ));
            Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.Euler(Vector3.up));
            numEnemies -= 1;
        }
    } 

    
}
