﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletCollisionManager : MonoBehaviour
{
    private GameObject scoreDisplay;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.Find("ScoreDisplay");
        scoreManager = scoreDisplay.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            scoreManager.Score++;
        }
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
