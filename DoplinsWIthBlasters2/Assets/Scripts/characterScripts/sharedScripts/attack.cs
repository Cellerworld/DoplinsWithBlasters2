using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {
	private Sword sword;

	private Animator _animator;


	// Use this for initialization
	void Start () {
		sword = GetComponentInChildren<Sword>();
		_animator = this.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Attack();
		}
	}

	private void Attack()
	{
		sword.isAttacking = true;
		_animator.SetTrigger("hit");
	}

	private void EndAttack()
	{
		sword.isAttacking = false;
		_animator.SetTrigger ("idle");
	}
}
