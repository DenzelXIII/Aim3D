using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DestroyDelay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
