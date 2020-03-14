using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Quaternion (bulletPrefab.transform.rotation.x, transform.rotation.y, bulletPrefab.transform.rotation.z, bulletPrefab.transform.rotation.w));
        }
        
    }
}
