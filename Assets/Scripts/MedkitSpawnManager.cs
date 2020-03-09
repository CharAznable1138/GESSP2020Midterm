using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject medkitPrefab;
    [SerializeField] float startDelay = 10;
    [SerializeField] float repeatRate = 10;
    [SerializeField] float spawnRangeX = 20;
    [SerializeField] float spawnPosZ = 20.3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMedkit", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMedkit()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
        Instantiate(medkitPrefab, spawnPos, medkitPrefab.transform.rotation);
    }
}
