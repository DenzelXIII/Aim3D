using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;



	// Use this for initialization
	void Start () {
	
	}

    void TakeDamage(int dmgAmount)
    {
        health = health - dmgAmount;

        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
