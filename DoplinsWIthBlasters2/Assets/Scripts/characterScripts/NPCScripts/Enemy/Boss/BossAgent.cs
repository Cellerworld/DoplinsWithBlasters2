using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAgent : MonoBehaviour
{

    private Animator _anim;
    private NavMeshAgent _agent;
    [SerializeField]
    private Player _player;
    [SerializeField]
    private GameObject _base;
    private BossAbstractState _state;
    [SerializeField]
    private float _range;
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _timeBtwAttacks;
    private float _currentTimeBtwAttacks;
    private Rigidbody _rb;
    [SerializeField]
    private EnemyAttack _leftSword;
    [SerializeField]
    private EnemyAttack _rightSword;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _state = BossChargeTownState.GetInstance();
        _rb = GetComponent<Rigidbody>();
    }

    private void SetState(BossAbstractState state)
    {
        if (_state != null)
        {
            _state.Exit(this);
        }
        _state = state;
        _state.Enter(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _range);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
