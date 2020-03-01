using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Credit to this thread for telling me about the LookAt() function: https://answers.unity.com/questions/661639/how-can-i-make-a-game-object-look-at-another-objec.html

public class EnemyTurretAim : MonoBehaviour
{
    private GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(playerObject.transform);
    }


}
