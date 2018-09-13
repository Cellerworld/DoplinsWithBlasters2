using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("i hit something");
        Debug.Log(other.tag);
        if(other.tag == "Player" || other.tag == "Base")
        {
            //TODO make sure the enemy only deals damage while he is attacking
            //do damage!!
            //remove random number by attack power
            Debug.Log("ATTACK");
            other.GetComponent<Stats>().ReceiveDamage(5);
        }
    }
}
