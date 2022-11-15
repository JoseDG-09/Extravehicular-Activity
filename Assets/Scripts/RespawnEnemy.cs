using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnMinRangex = 0;
    private float spawnMaxRangeX = 50;
    private float spawnPosY = 13;
    private float spawnPosZ = 93;
    private float startDelay = 30;
    private float spawnInterval = 30;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyController", spawnInterval, startDelay);
    }

    private void SpawnEnemyController()
    {
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnMinRangex, spawnMaxRangeX), spawnPosY, spawnPosZ);
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }
}
