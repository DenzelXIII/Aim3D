using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private float startTimer;
    [SerializeField]
    private float nextEnemyWaveTimer;

    private int _enemyAmount = 3;
    public int maxEnemies;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("SpawnEnemies", startTimer, nextEnemyWaveTimer);
	}


    void SpawnEnemies()
    {
        for (int i = 0; i < _enemyAmount; i++)
        {
            Instantiate(_enemy, spawnPoints[(Random.Range(0, spawnPoints.Length))].position, Quaternion.identity);
        }
        _enemyAmount = _enemyAmount + 1;
        if (_enemyAmount >= maxEnemies)
        {
            _enemyAmount = maxEnemies;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
