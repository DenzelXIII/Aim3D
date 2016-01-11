﻿using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float maxLifeTime;
    [SerializeField]
    private float _dmg = 1f;
    private float lifeTime = 0f;
    private float power;
    [SerializeField]private GameObject explosionPrefab;
    private Tags _tags;

    
    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float delta = Time.deltaTime;
        transform.Translate(Vector3.forward * speed * delta);
        lifeTime += delta;
        if (lifeTime > maxLifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _tags.enemyTag)
        {
            other.gameObject.SendMessage("TakeDamage", power);
        }
        Destroy(this.gameObject);
        //Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
            other.SendMessage("ApplyDamage", _dmg);
            Destroy(this.gameObject);
        }
    }
}
