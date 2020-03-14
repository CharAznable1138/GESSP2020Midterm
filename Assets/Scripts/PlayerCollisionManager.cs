using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionManager : MonoBehaviour
{
    private int Health = 100;
    private PlayerController playerController;
    private LaunchProjectile Launcher;
    private RotateTurret rotateTurret;
    [SerializeField] GameObject enemySpawner;
    private EnemySpawnManager enemySpawnerScript;
    [SerializeField] GameObject medkitSpawner;
    private MedkitSpawnManager medkitSpawnerScript;
    [SerializeField] GameObject healthDisplay;
    private Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        enemySpawnerScript = enemySpawner.GetComponent<EnemySpawnManager>();
        Launcher = GetComponentInChildren<LaunchProjectile>();
        rotateTurret = GetComponentInChildren<RotateTurret>();
        medkitSpawnerScript = medkitSpawner.GetComponent<MedkitSpawnManager>();
        healthText = healthDisplay.GetComponent<Text>();
        healthText.text = $"Structural Integrity: {Health}%";
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
            if (Health > 0)
            {
                Health -= 10;
            }
            else
            {
                Health = 0;
            }
            //Debug.Log($"Player just took 1 damage and has {Health} health remaining.");
            healthText.text = $"Structural Integrity: {Health}%";
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
            Health += 100;
            if (Health >= 100)
            {
                Health = 100;
            }
            healthText.text = $"Structural Integrity: {Health}%";
            //Debug.Log($"Player just got a medkit and has been restored to {Health} health.");
        }
    }
}
