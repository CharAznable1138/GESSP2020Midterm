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
    [SerializeField] float minRepeatTime = 1;
    [SerializeField] float maxRepeatTime = 10;
    [SerializeField] GameObject player;
    private PlayerCollisionManager playerCollisionManager;
    // Start is called before the first frame update
    void Start()
    {
        playerCollisionManager = player.GetComponentInChildren<PlayerCollisionManager>();
        StartCoroutine("SpawnEnemyTop");
        StartCoroutine("SpawnEnemyLeft");
        StartCoroutine("SpawnEnemyRight");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyTop()
    {
        while (!playerCollisionManager.gameOver)
        {
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
        }
        yield return null;
    }

    IEnumerator SpawnEnemyLeft()
    {
        while (!playerCollisionManager.gameOver)
        {
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(spawnRangeZNega, spawnRangeZPosi));
            Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(0, 270, 0));
        }
        yield return null;
    }

    IEnumerator SpawnEnemyRight()
    {
        while (!playerCollisionManager.gameOver)
        {
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPos = new Vector3(-spawnPosX, 0, Random.Range(spawnRangeZNega, spawnRangeZPosi));
            Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(0, 90, 0));
        }
        yield return null;
    }
}
