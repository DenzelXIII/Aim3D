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
            _anim.SetBool("isWalking", false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        FollowTarget();
	}
}
