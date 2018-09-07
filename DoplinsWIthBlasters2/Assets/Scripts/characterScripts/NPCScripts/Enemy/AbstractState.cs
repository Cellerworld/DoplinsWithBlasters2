using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public abstract class AbstractState {

    public abstract void Enter(EnemyAgent agent);
    public abstract void Update(EnemyAgent agent);
    public abstract void Exit(EnemyAgent agent);
}
