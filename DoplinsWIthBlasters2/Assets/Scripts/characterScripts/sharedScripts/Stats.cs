using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

//Monitors all stats of the object and changes them according to input
public class Stats : MonoBehaviour {


	private bool _isInvincible = false;
	private float _invincibleTime = 0;

	[SerializeField]
	private int _attackPower;

	void Update()
	{
		if (_invincibleTime > 0) {
			_invincibleTime -= Time.deltaTime;
		}
		else
		{
			_isInvincible = false;
		}
	}

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
		if (!_isInvincible) {
			
			_currentHealthPoints -= damage;

			if (gameObject.tag == "Player") {
				_isInvincible = true;
				_invincibleTime = 1.5f;
			}

			if (_currentHealthPoints <= 0) {
				Debug.Log ("I died");
				//set trigger for gameover event
				if (gameObject.tag == "Player") {
					//set the trigger
				}
                else if(gameObject.tag == "Enemy" || gameObject.tag == "EnemyWave")
                {
                    GetComponent<BoxCollider>().enabled = false;
                    transform.GetChild(0).gameObject.SetActive(false);
                    AudioSource source = GetComponent<AudioSource>();
                    source.clip = FindObjectOfType<EnemyAudio>().GetEnemyDeathSound();
                    source.Play();
                    
					Destroy (gameObject, 0.5f);
				}
                else
                {
                    Destroy(gameObject);
                }
			}
		}
	}

	public void IncreaseHealth(int pHealthBonus)
	{
		_maxHealthPoints += pHealthBonus;
	}
}
