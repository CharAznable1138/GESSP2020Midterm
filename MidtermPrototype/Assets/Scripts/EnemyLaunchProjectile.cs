using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float startDelay = 1;
    [SerializeField] float repeatRate = 1;
    [SerializeField] float rotationModifier = 1;
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
        Instantiate(bulletPrefab, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y * rotationModifier, transform.rotation.z, transform.rotation.w));
    }
}
