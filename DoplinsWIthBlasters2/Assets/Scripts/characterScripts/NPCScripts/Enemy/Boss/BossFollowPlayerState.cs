using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowPlayerState : BossAbstractState {

    private static BossFollowPlayerState _instance;

    public static BossFollowPlayerState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new BossFollowPlayerState();
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
