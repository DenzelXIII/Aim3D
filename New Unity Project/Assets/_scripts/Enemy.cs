using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    [SerializeField]private float _enemyHealth = 10;
	// Use this for initialization
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
}
