using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    private AudioSource firingNoise;
    // Start is called before the first frame update
    void Start()
    {
        firingNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            firingNoise.Play();
            Instantiate(bulletPrefab, new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Quaternion (bulletPrefab.transform.rotation.x, transform.rotation.y, bulletPrefab.transform.rotation.z, bulletPrefab.transform.rotation.w));
        }
        
    }
}
