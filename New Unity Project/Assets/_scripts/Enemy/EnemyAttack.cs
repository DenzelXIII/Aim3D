using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
   // [HideInInspector]
    public bool isAttacking;
    private Tags _tags;
    [SerializeField]
    private int _attackPower;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void Attack()
    {

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == _tags.playerTwoTag)
        {
            print("attacking player");
            coll.gameObject.SendMessage("TakeDamage",_attackPower);
        }
    }
}
