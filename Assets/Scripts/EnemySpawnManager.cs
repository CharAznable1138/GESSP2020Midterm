using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float startDelayTop = 1;
    [SerializeField] float startDelaySides = 5;
    [SerializeField] float repeatRate = 1;
    [SerializeField] float spawnRangeX = 20;
    [SerializeField] float spawnPosZ = 20.3f;
    [SerializeField] float spawnPosX = 20.3f;
    [SerializeField] float spawnRangeZPosi = 20;
    [SerializeField] float spawnRangeZNega = -10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyTop", startDelayTop, repeatRate);
        InvokeRepeating("SpawnEnemyLeft", startDelaySides, repeatRate);
        InvokeRepeating("SpawnEnemyRight", startDelaySides, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyTop()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }

    void SpawnEnemyLeft()
    {
        Vector3 spawnPos = new Vector3(spawnPosX, 1, Random.Range(spawnRangeZNega, spawnRangeZPosi));
        Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(0, 270, 0));
    }

    void SpawnEnemyRight()
    {
        Vector3 spawnPos = new Vector3(-spawnPosX, 1, Random.Range(spawnRangeZNega, spawnRangeZPosi));
        Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(0, 90, 0));
    }
}
