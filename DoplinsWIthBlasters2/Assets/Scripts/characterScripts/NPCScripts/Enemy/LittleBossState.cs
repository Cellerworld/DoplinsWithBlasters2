using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LittleBossState {

    public abstract void Enter(LittleBossAgent agent);
    public abstract void Update(LittleBossAgent agent);
    public abstract void Exit(LittleBossAgent agent);
}
