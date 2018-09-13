using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour {

    [SerializeField]
    private bool _isWaveEnemy;
    [SerializeField]
    private GameObject[] _waypoints;
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _timeBtwAttacks;
    [SerializeField]
    private Player _player;
    [SerializeField]
    private GameObject _base;
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _followRange;

    private float _currentTimeBtwAttacks;
    private AbstractState _state;
    [SerializeField]
    private Animator _anim;
    private NavMeshAgent _agent;
    private int index = 0;
    [SerializeField]
    private Rigidbody rb;

	[SerializeField]
	private EnemyAttack _leftSword;
	[SerializeField]
	private EnemyAttack _rightSword;

    private void OnEnable()
    {
        //find player if player == null
        if(_player == null)
        {
            _player = FindObjectOfType<Player>();
        }

        if(_base == null)
        {
            _base = GameObject.FindGameObjectWithTag("Base");
        }

        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _movementSpeed;

        //depends on _isWaveEnemy
        if (_isWaveEnemy == false)
        {
            SetState(PatrolState.GetInstance());
        }
        else
        {
            SetState(ChargeBaseState.GetInstance());
        }
    }

    private void OnApplicationQuit()
    {
        if(_isWaveEnemy)
        {
            GetComponent<Enemy>().enabled = false;
            Destroy(gameObject);
        }
    }

    public void SetIsWaveEnemy(bool waveEnemy)
    {
        _isWaveEnemy = waveEnemy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _followRange);
    }

    void Update()
    {
           _state.Update(this);
    }

    public void SetState(AbstractState state)
    {
        if(_state != null)
        {
            _state.Exit(this);
        }
        _state = state;
        _state.Enter(this);
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public void UpdateWaypoint()
    {
        _agent.destination = _waypoints[index].transform.position;
        index++;
        index = index % _waypoints.Length;
    }

    public void SetPlayerTarget()
    {
        _agent.destination = _player.transform.position;
    }

    public void SetBaseTarget()
    {
        _agent.destination = _base.transform.position;
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return _agent;
    }

    public float GetFollowRange()
    {
        return _followRange;
    }

    public float GetAttackRange()
    {
        return _attackRange;
    }

    public void Attack()
    {
        _currentTimeBtwAttacks = _timeBtwAttacks;
    }

    public void ResetAttack()
    {
        _currentTimeBtwAttacks = 0;
    }

    public void AdjustAttackTime()
    {
        _currentTimeBtwAttacks -= Time.deltaTime;
    }

    public float GetCurrentTimeBtwAttacks()
    {
        return _currentTimeBtwAttacks;
    }

    public bool GetIsWaveEnemy()
    {
        return _isWaveEnemy;
    }

    public void SetAnimation(bool isAttacking)
    {
        _anim.SetBool("isAttacking", isAttacking);
		_leftSword.enabled = isAttacking;
		_rightSword.enabled = isAttacking;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}