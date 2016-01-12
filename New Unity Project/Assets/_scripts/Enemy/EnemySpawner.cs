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
    private int _layermask;
    private Tags _tags;
    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }
    // Use this for initialization
    void Start ()
    {
        //InvokeRepeating("SpawnEnemies", startTimer, nextEnemyWaveTimer);
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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == _tags.playerTag)
        {
            print("Player is in range, spawn enemies?");
            //InvokeRepeating("SpawnEnemies", startTimer, nextEnemyWaveTimer);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

	}
}
