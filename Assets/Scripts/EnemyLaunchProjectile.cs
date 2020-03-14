using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float startDelay = 1;
    [SerializeField] float repeatRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchProjectile()
    {
        Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }
}
