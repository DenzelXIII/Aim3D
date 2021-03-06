﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float _enemyHealth;
    [SerializeField]
    private float enemyPower;
    protected Tags _tags;
    public string targetTag;
    protected Animator _anim;
    private bool _isAttacking;
    public delegate void OnDeath();
    public static event OnDeath EnemyDeath;


    // Use this for initialization

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
        _anim = GetComponent<Animator>();
    }

    void Start ()
    {
        _tags.GiveTag(_tags.enemyTag, this.gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
        if (_enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            EnemyDeath();
        }
    }

    void TakeDamage(float _dmg)
    {
        _enemyHealth = _enemyHealth - _dmg;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            other.SendMessage("Damage", enemyPower);
        }
    }
}
