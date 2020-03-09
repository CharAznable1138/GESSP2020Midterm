using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private int Health = 10;
    private PlayerController playerController;
    private LaunchProjectile Launcher;
    private RotateTurret rotateTurret;
    [SerializeField] GameObject enemySpawner;
    private EnemySpawnManager enemySpawnerScript;
    [SerializeField] GameObject medkitSpawner;
    private MedkitSpawnManager medkitSpawnerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        enemySpawnerScript = enemySpawner.GetComponent<EnemySpawnManager>();
        Launcher = GetComponentInChildren<LaunchProjectile>();
        rotateTurret = GetComponentInChildren<RotateTurret>();
        medkitSpawnerScript = medkitSpawner.GetComponent<MedkitSpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            Health --;
            Debug.Log($"Player just took 1 damage and has {Health} health remaining.");
            if(Health <= 0)
            {
                Health = 0;
                playerController.enabled = false;
                Launcher.enabled = false;
                rotateTurret.enabled = false;
                medkitSpawnerScript.CancelInvoke();
                enemySpawnerScript.CancelInvoke();
                Debug.Log("Game over, man! Game over!");
            }
        }
        if(collision.gameObject.CompareTag("Medkit"))
        {
            Destroy(collision.gameObject);
            Health += 10;
            if (Health >= 10)
            {
                Health = 10;
            }
            Debug.Log($"Player just got a medkit and has been restored to {Health} health.");
        }
    }
}
