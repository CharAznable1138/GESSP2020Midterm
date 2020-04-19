using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    private AudioSource firingNoise;
    [SerializeField] float delay = 1;
    private bool coolDown;
    [SerializeField] GameObject cooldownDisplay;
    // Start is called before the first frame update
    void Start()
    {
        firingNoise = GetComponent<AudioSource>();
        coolDown = false;
        cooldownDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !coolDown)
        {
            firingNoise.Play();
            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(bulletPrefab.transform.rotation.x, transform.rotation.y, bulletPrefab.transform.rotation.z, bulletPrefab.transform.rotation.w));
            StartCoroutine("Cooldown");
        }
    }

    IEnumerator Cooldown()
    {
        coolDown = true;
        cooldownDisplay.SetActive(true);
        yield return new WaitForSeconds(delay);
        coolDown = false;
        cooldownDisplay.SetActive(false);
        yield return null;
    }
}
