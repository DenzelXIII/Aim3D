using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float maxDistance;

    private Transform target;
    [SerializeField]
    private string targetTag;
    private Tags _tags;
    private EnemyAttack _attack;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
        _attack = GetComponent<EnemyAttack>();
    }

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
	}

    void FollowTarget()
    {
        transform.LookAt(target);

        if (Vector3.Distance(transform.position,target.position) >= minDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (Vector3.Distance(transform.position,target.position) <= maxDistance)
        {
            Debug.Log("what do");
            _attack.isAttacking = true;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        FollowTarget();
	}
}
