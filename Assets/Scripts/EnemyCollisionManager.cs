using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionManager : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerProjectile"))
        {
            Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
