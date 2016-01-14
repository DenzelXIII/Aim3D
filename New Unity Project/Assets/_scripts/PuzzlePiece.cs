using UnityEngine;
using System.Collections;

public class PuzzlePiece : MonoBehaviour {

    private int _numberOfPieces = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.SendMessage("PuzzlePieceCollected", _numberOfPieces);
            Destroy(this.gameObject);
        }
    }
}
