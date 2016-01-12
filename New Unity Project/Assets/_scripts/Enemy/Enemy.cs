using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    [SerializeField]private float _enemyHealth;
    [SerializeField] private float movementSpeed;
    private Tags _tags;
    // Use this for initialization

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (_enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
	
	}

    void ApplyDamage(float _damage)
    {
        _enemyHealth -= _damage;
    }

    void StrengthIncrease()
    {
        movementSpeed = movementSpeed + 1.5f;
        _enemyHealth = _enemyHealth + 20;
    }

    void StrengthDecrease()
    {
        movementSpeed = movementSpeed - 1.5f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _tags.strongBulletTag)
        {
            StrengthIncrease();
        }else if(other.gameObject.tag == _tags.WeakBulletTag)
        {
            StrengthDecrease();
        }
    }
}
