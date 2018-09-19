using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour {

    [SerializeField]
    private AudioClip[] _enemyAttackSounds;
    [SerializeField]
    private AudioClip[] _enemyDeathSounds;

    public AudioClip GetEnemyAttackSound()
    {
        return _enemyAttackSounds[Random.Range(0, _enemyAttackSounds.Length - 1)];
    }

    public AudioClip GetEnemyDeathSound()
    {
        return _enemyDeathSounds[Random.Range(0, _enemyDeathSounds.Length - 1)];
    }
}
