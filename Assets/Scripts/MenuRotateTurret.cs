using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotateTurret : MonoBehaviour
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
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);

        if(transform.rotation.y >= turnLimit || transform.rotation.y < 0)
        {
            turnSpeed *= -1;
        }

    }
}
