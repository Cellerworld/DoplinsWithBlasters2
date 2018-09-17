using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LittleBossAgent : MonoBehaviour
{

    [SerializeField]
    Player _player;
    [SerializeField]
    Animator _anim;
    [SerializeField]
    NavMeshAgent _agent;
    [SerializeField]
    GameObject _returnPoint;
    [SerializeField]
    float _range;
    [SerializeField]
    float _attackRange;
    [SerializeField]
    float _timeBtwAttacks;
    float _currentTimeBtwAttacks;
    [SerializeField]
    EnemyAttack _leftSword;
    [SerializeField]
    EnemyAttack _rightSword;
    Rigidbody _rb;

    LittleBossState _state;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _state = LittleBossIdleState.GetInstance();
    }

    private void Update()
    {
        if (_state != null)
            _state.Update(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    public float GetTimeBtwAttacks()
    {
        return _timeBtwAttacks;
    }

    public float GetCurrentTimeBtwAttacks()
    {
        return _currentTimeBtwAttacks;
    }

    public void UpdateAttackTime()
    {
        _currentTimeBtwAttacks -= Time.deltaTime;
    }

    public float GetAttackRange()
    {
        return _attackRange;
    }

    public float GetRange()
    {
        return _range;
    }

    public void SetState(LittleBossState state)
    {
        if(_state != null)
        _state.Exit(this);
        _state = state;
        _state.Enter(this);
    }

    public Vector3 GetDestination()
    {
        return _agent.destination;
    }

    public void SetAnimationTrigger(string animationName)
    {
        _anim.SetTrigger(animationName);
    }

    public void SetPlayerAsDestination()
    {
        _agent.destination = _player.transform.position;
    }

    public void ResetDestination()
    {
        _agent.destination = _returnPoint.transform.position;
    }

    public float GetDistanceBtwPlayerAndReturn()
    {
        return Vector3.Distance(_player.transform.position, _returnPoint.transform.position);
    }

    public void DeactivateMoving()
    {
        _agent.isStopped = true;
    }

    public void ActivateMoving()
    {
        _agent.isStopped = false;
    }

    public void Attack()
    {
        _currentTimeBtwAttacks = _timeBtwAttacks;
    }

    public void ResetAttack()
    {
        _currentTimeBtwAttacks = 0;
    }

    public void SetAnimation(bool isAttacking)
    {
        if(isAttacking == false)
        {
            _anim.SetBool("isAttacking", isAttacking);
            _anim.SetBool("strongAttack", isAttacking);
        }
        else
        {
            if(Random.Range(0, 100) < 20)
            {
                _anim.SetBool("strongAttack", isAttacking);
            }
            else
            {
                _anim.SetBool("isAttacking", isAttacking);
            }
        }
        _leftSword.enabled = isAttacking;
        _rightSword.enabled = isAttacking;
    }

    public Rigidbody GetRigidbody()
    {
        return _rb;
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return _agent;
    }
}
