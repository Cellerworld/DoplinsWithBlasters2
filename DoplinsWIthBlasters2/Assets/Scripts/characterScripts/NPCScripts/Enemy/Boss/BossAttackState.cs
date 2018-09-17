using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossAbstractState {

    private static BossAttackState _instance;

    public static BossAttackState GetInstance()
    {
        if(_instance == null)
        {
            _instance = new BossAttackState();
        }
        return _instance;
    }

    public override void Enter(BossAgent agent)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(BossAgent agent)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit(BossAgent agent)
    {
        throw new System.NotImplementedException();
    }
}
