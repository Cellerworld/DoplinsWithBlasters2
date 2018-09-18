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
    public int MaxHealthPoints
    {
        get
        {
            return _maxHealthPoints;
        }
    }

	[SerializeField]
	private int _currentHealthPoints;
    public int CurrentHealthPoints
    {
        get
        {
            return _currentHealthPoints;
        }
    }

	[SerializeField]
	private int _movementSpeed;
    public int Speed
    {
        get
        {
            return _movementSpeed;
        }
    }

    [SerializeField]
    GameObject _deathParticle;

    private void OnApplicationQuit()
    {
        _deathParticle = null;
    }

    private void OnDestroy()
    {
        if (_deathParticle != null)
        {
            Destroy(Instantiate(_deathParticle, transform.position, Quaternion.identity), 1f);
        }
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
            Debug.Log("I died");
			//set trigger for gameover event
            if(gameObject.tag == "Player")
            {
                //set the trigger
            }
            else
            {
                Destroy(gameObject);
            }
		}
	}

	public void IncreaseHealth(int pHealthBonus)
	{
		_maxHealthPoints += pHealthBonus;
	}
}
