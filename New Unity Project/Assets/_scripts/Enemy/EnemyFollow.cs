using UnityEngine;
using System.Collections;

public class EnemyFollow : Enemy
{
    public float moveSpeed;
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float maxDistance;

    private Transform target;
    [SerializeField]
    private string targetTag;
   // private EnemyAttack _attack;

  /*  void Awake()
    {
        _tags = FindObjectOfType<Tags>();
      //  _attack = GetComponent<EnemyAttack>();
    }
*/
	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
        Debug.Log(_anim);
	}

    void FollowTarget()
    {
        transform.LookAt(target);

        if (Vector3.Distance(transform.position,target.position) >= minDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            _anim.SetBool("isWalking", true);
        }
        else if (Vector3.Distance(transform.position,target.position) <= maxDistance)
        {
            Debug.Log("what do");
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isAttacking",true);
           // _attack.isAttacking = true;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        FollowTarget();
	}
}
