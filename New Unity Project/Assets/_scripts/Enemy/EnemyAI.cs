using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        RayCastForward();
	}

    void RayCastForward()
    {
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(transform.position,forward,20))
        {
            Debug.Log("Colliding with something in front of me");
        }
    }
}
