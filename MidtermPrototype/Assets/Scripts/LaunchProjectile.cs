using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float rotationModifier = 1;
    [SerializeField] float zOffset = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, new Vector3 (transform.position.x, transform.position.y, transform.position.z + zOffset), new Quaternion (bulletPrefab.transform.rotation.x, transform.rotation.y * rotationModifier, bulletPrefab.transform.rotation.z, bulletPrefab.transform.rotation.w));
        }
        
    }
}
