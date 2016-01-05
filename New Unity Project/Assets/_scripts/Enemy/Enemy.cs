using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    private float _maxDist;
    private float _minDist;
    private GameObject target;
    private Vector3 _targetPos;

    // Use this for initialization
    void Start ()
    {
        _targetPos = Pos();
    }

    Vector3 Pos()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        return pos;
    }


    void EnemyFollow()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, movementSpeed * Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        EnemyFollow();
	}
}
