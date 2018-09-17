using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LittleBossAgent : MonoBehaviour {

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
    [SerializeField]
    float _currentTimeBtwAttacks;

    LittleBossState _state;

    private void Start()
    {
        _state = LittleBossIdleState.GetInstance();
    }

    private void Update()
    {
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
        _state = state;
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
}
