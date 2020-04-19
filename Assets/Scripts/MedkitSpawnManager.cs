using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject medkitPrefab;
    [SerializeField] float spawnRangeX = 20;
    [SerializeField] float spawnPosZ = 20.3f;
    [SerializeField] float minRepeatTime = 10;
    [SerializeField] float maxRepeatTime = 20;
    [SerializeField] GameObject player;
    private PlayerCollisionManager playerCollisionManager;
    // Start is called before the first frame update
    void Start()
    {
        playerCollisionManager = player.GetComponentInChildren<PlayerCollisionManager>();
        StartCoroutine("SpawnMedkit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMedkit()
    {
        while (!playerCollisionManager.gameOver)
        {
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
            Instantiate(medkitPrefab, spawnPos, medkitPrefab.transform.rotation);
        }
        yield return null;
    }
}
