using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChargeTownState : BossAbstractState {

    private static BossChargeTownState _instance;

    public static BossChargeTownState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new BossChargeTownState();
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
