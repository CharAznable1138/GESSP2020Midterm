using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerOnTouch : MonoBehaviour
{
    private GameObject enemySpawnManager;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnManager = GameObject.Find("EnemySpawnManager");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemySpawnManager.GetComponent<EnemySpawnManager>().CancelInvoke();
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Player just died");
            Debug.Log("Game over, man! Game over!");
        }
    }
}
