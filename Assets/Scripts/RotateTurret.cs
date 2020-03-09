using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurret : MonoBehaviour
{
    [SerializeField] float turnSpeed = 10;
    [SerializeField] float turnLimit = 45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.rotation.y < -turnLimit)
        {
            transform.rotation = new Quaternion(transform.rotation.x, -turnLimit, transform.rotation.z, transform.rotation.w);
        }

        if (transform.rotation.y > turnLimit)
        {
            transform.rotation = new Quaternion(transform.rotation.x, turnLimit, transform.rotation.z, transform.rotation.w);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }

    }
}
