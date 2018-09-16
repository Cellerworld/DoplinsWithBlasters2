using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public bool isAttacking = false;

    [SerializeField]
    Stats _playerStats;

    private void OnTriggerEnter(Collider other)
    {
        if(isAttacking && (other.tag == "Enemy" || other.tag == "EnemyWave"))
        {
            other.GetComponent<Stats>().ReceiveDamage(_playerStats.AttackPower);
        }
		if(isAttacking && (other.tag == "Destructable" || other.tag == "Destructable2"))
        {
            Destroy(other.gameObject);
        }
    }
}
