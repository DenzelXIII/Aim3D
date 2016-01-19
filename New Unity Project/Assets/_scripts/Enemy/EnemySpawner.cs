﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject[] _enemy;
    private int _enemyAmount;
    public int maxEnemiesOnField;
    private bool canSpawn;
    private Tags _tags;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }

    void Start()
    {
        canSpawn = true;
    }

    void SpawnEnemies()
    {
            if (canSpawn)
            {
                if (_enemyAmount < maxEnemiesOnField)
                {
                    Instantiate(_enemy[(Random.Range(0,_enemy.Length))], spawnPoints[(Random.Range(0, spawnPoints.Length))].position, Quaternion.identity);
                    _enemyAmount++;
                }
            }
        if (_enemyAmount == maxEnemiesOnField)
        {
            canSpawn = false;
        }
    }

    void EnemyCheck()
    {
        _enemyAmount--;
    }

    void OnEnable()
    {
        Enemy.EnemyDeath += EnemyCheck;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == _tags.playerOneTag || other.gameObject.tag == _tags.playerTwoTag)
        {
            SpawnEnemies();
        }
    }
}
