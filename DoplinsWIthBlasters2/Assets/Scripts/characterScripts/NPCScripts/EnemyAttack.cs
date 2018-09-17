using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Base")
        {
            //TODO make sure the enemy only deals damage while he is attacking
            //do damage!!
            //remove random number by attack power
            other.GetComponent<Stats>().ReceiveDamage(5);
        }
    }
}
