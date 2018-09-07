using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    [SerializeField]
    float _timeBtwAttacks;
    float _currentTimeBtwAttacks;

    [SerializeField]
    float _attackRange;

    Animator _anim;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
	}
	
    public void Attack()
    {
        //block movement
        //do attack stuff
        //reset attack
        //allow movement again
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
