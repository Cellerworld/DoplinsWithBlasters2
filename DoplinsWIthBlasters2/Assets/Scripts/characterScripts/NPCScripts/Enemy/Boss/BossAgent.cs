using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAgent : MonoBehaviour
{
    [SerializeField]
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

    private bool _isAttacking;
    private float _attackDuration;

    private void Start()
    {
        _isAttacking = false;
        _agent = GetComponent<NavMeshAgent>();
        SetState(BossChargeTownState.GetInstance());
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Destructable2")
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_isAttacking == false)
        {
            _state.Update(this);
            _currentTimeBtwAttacks -= Time.deltaTime;
        }
        else
        {
            _attackDuration -= Time.deltaTime;
            if (_attackDuration <= 0)
            {
                ResetIsAttacking();
            }
        }
    }

    private void ResetIsAttacking()
    {
        _isAttacking = false;
    }

    public void Attack()
    {
        _isAttacking = true;
        _currentTimeBtwAttacks = _timeBtwAttacks;

        StartAttackAnimation();
    }

    public void SetBaseAsTarget()
    {
        _agent.destination = _base.transform.position;
    }

    public void SetPlayerAsTarget()
    {
        _agent.destination = _player.transform.position;
    }

    private void StartAttackAnimation()
    {
        //do magic math stuff to decide which animation is played and play animation
        int rnd = Random.Range(0, 100);

        //TODO remove magic numbers by values that can be set within the inspector
        if (rnd <= 10)
        {
            //do super attack
            _anim.SetTrigger("super");
            _attackDuration = 4.5f;
        }
        else if (rnd <= 35)
        {
            //do strong attack
            _anim.SetTrigger("strong");
            _attackDuration = 0.5f;
        }
        else
        {
            //do normal attack
            _anim.SetTrigger("normal");
            _attackDuration = 1.4f;
        }
    }

    public float GetTimeBtwAttacks()
    {
        return _currentTimeBtwAttacks;
    }

    public bool GetIsBaseInAttackRange()
    {
        return Vector3.Distance(_base.transform.position, transform.position) < _attackRange;
    }

    public bool GetIsPlayerInAttackRange()
    {
        return Vector3.Distance(_player.transform.position, transform.position) < _attackRange;
    }

    public bool GetIsPlayerInRange()
    {
        return Vector3.Distance(_player.transform.position, transform.position) < _range;
    }

    public void SetState(BossAbstractState state)
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
