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
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject finalScoreDisplay;
    private FinalScoreDisplay finalScoreDisplayer;
    [SerializeField] GameObject smoke;
    [SerializeField] GameObject explosion;
    private AudioSource hitSound;
    internal bool gameOver;
    private AudioSource lowHealthNoise;
    private AudioSource repairNoise;

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
        finalScoreDisplayer = finalScoreDisplay.GetComponent<FinalScoreDisplay>();
        hitSound = GetComponent<AudioSource>();
        gameOver = false;
        lowHealthNoise = healthDisplay.GetComponent<AudioSource>();
        repairNoise = medkitSpawner.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Health > 80)
        {
            healthText.color = new Color32(0, 255, 52, 255);
            lowHealthNoise.enabled = false;
        }
        else if (Health > 50)
        {
            healthText.color = new Color32(255, 227, 0, 255);
            lowHealthNoise.enabled = false;
        }
        else
        {
            healthText.color = new Color32(255, 10, 0, 255);
            lowHealthNoise.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            if (Health > 0)
            {
                Health -= 10;
                hitSound.Play();
            }
            else
            {
                Health = 0;
            }
            //Debug.Log($"Player just took 1 damage and has {Health} health remaining.");
            healthText.text = $"Structural Integrity: {Health}%";
            if(gameOver == false && Health <= 0)
            {
                gameOver = true;
                Health = 0;
                playerController.enabled = false;
                Launcher.enabled = false;
                rotateTurret.enabled = false;
                explosion.SetActive(true);
                smoke.SetActive(true);
                medkitSpawnerScript.CancelInvoke();
                enemySpawnerScript.CancelInvoke();
                //Debug.Log("Game over, man! Game over!");
                HUD.SetActive(false);
                gameOverScreen.SetActive(true);
                finalScoreDisplayer.Invoke("ShowFinalScore", 0);
            }
        }
        if(collision.gameObject.CompareTag("Medkit"))
        {
            Destroy(collision.gameObject);
            if(Health < 100)
            {
                if (!gameOver)
                {
                    repairNoise.Play();
                }
            }
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
