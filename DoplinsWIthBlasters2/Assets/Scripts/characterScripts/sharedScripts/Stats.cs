using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Monitors all stats of the object and changes them according to input
public class Stats : MonoBehaviour {

	[SerializeField]
	private int _attackPower;
	public int AttackPower
	{
		get
		{
			return _attackPower;
		}
	}

	[SerializeField]
	private int _maxHealthPoints;

	[SerializeField]
	private int _currentHealthPoints;

	[SerializeField]
	private int _movementSpeed;
    public int Speed
    {
        get
        {
            return _movementSpeed;
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	public void IncreaseAttack(int pAttackBonus)
	{
		_attackPower += pAttackBonus;
	}

	public void Heal(int pHealing)
	{
		_currentHealthPoints += pHealing;

		if (_currentHealthPoints > _maxHealthPoints)
		{
			_currentHealthPoints = _maxHealthPoints;
		}
	}

	public void ReceiveDamage(int damage)
	{
		_currentHealthPoints -= damage;

		if(_currentHealthPoints <= 0) 
		{
			//set trigger for gameover event
		}
	}

	public void IncreaseHealth(int pHealthBonus)
	{
		_maxHealthPoints += pHealthBonus;
	}
}
