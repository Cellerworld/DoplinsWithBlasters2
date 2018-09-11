using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyToSpawn;
    [SerializeField]
    int _enemyAmountToSpawn;
    [SerializeField]
    float _timeBtwWaves;
    [SerializeField]
    float _timeBtwEnemies;
    float _currentTimeBtwWaves;
    [SerializeField]
    [Header("This list MUST NOT! be empty!")]
    GameObject[] _spawnPoints;
    GameObject[] _chosenSpawnsPoints;
    [Header("Numbers can´t be greater than the array of spawnpoints")]
    [SerializeField]
    int _minAmountOfSpawns = 1;
    [SerializeField]
    int _maxAmountOfSpawns = 1;
    Stats _stats;
    bool isSpawning = false;

    private void Start()
    {
        _stats = GetComponent<Stats>();
        _currentTimeBtwWaves = _timeBtwWaves;
        if (_minAmountOfSpawns == 0)
        {
            _minAmountOfSpawns = 1;
        }
        if (_minAmountOfSpawns > _spawnPoints.Length)
        {
            _minAmountOfSpawns = _spawnPoints.Length;
        }
        if (_maxAmountOfSpawns < _minAmountOfSpawns)
        {
            _maxAmountOfSpawns = _minAmountOfSpawns;
        }
        if (_maxAmountOfSpawns > _spawnPoints.Length)
        {
            _maxAmountOfSpawns = _spawnPoints.Length;
        }
    }

    private void Update()
    {
        if (_currentTimeBtwWaves > 0)
        {
            _currentTimeBtwWaves -= Time.deltaTime;
        }
        else if(isSpawning == false)
        {
            isSpawning = true;
            //pick spawns
            PickSpawns();
            //spawn wave
            StartCoroutine("SpawnWave");
        }
    }

    void PickSpawns()
    {
        int rnd = Random.Range(_minAmountOfSpawns, _maxAmountOfSpawns);
        _chosenSpawnsPoints = new GameObject[rnd];
        for (int i = 0; i < rnd; i++)
        {
            _chosenSpawnsPoints[i] = _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)];
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < _enemyAmountToSpawn; i++)
        {
            SpawnEnemy(Random.Range(0, _chosenSpawnsPoints.Length - 1));

            yield return new WaitForSeconds(_timeBtwEnemies);
        }
        _currentTimeBtwWaves = _timeBtwWaves;
        isSpawning = false;
    }

    void SpawnEnemy(int i)
    {
        GameObject enemy = Instantiate(_enemyToSpawn, _chosenSpawnsPoints[i].transform.position, Quaternion.identity);
        enemy.GetComponent<NavMeshAgent>().speed = _stats.Speed;
        enemy.GetComponent<NavMeshAgent>().destination = Vector3.zero;

        EnemyAgent agent = enemy.GetComponent<EnemyAgent>();
        agent.SetIsWaveEnemy(true);
        agent.enabled = true;
    }
}
