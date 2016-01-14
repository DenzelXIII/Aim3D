using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float _enemyHealth;
    [SerializeField] private float movementSpeed;
    private Tags _tags;
    [SerializeField]
    private Transform[] _targets;

    public delegate void OnDeath();
    public static event OnDeath EnemyDeath;


    // Use this for initialization

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }

    void Start ()
    {
        _tags.GiveTag(_tags.enemyTag, this.gameObject);
        //EnemyDeath();
    }

    // Update is called once per frame
    void Update ()
    {
        if (_enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    void TakeDamage(float _dmg)
    {
        _enemyHealth = _enemyHealth - _dmg;
    }

    void GetStronger()
    {
        movementSpeed = movementSpeed + 1.5f;
        _enemyHealth = _enemyHealth + 20;
    }

    void GetWeakened()
    {
        movementSpeed = movementSpeed - 1.5f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _tags.strongBulletTag)
        {
            GetStronger();
            print("speed: " + movementSpeed + "and health: " + _enemyHealth);
        }else if(other.gameObject.tag == _tags.WeakBulletTag)
        {
            GetWeakened();
            print("speed: " + movementSpeed + "and health: " + _enemyHealth);
        }
    }
}
