using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAbstractState {

    public abstract void Enter(BossAgent agent);
    public abstract void Update(BossAgent agent);
    public abstract void Exit(BossAgent agent);
}
