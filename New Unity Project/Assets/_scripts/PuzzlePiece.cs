using UnityEngine;
using System.Collections;

public class PuzzlePiece : MonoBehaviour {

    private float _numberOfPieces = 1;
    private Renderer _rend;
    private AudioSource _collectSound;

	// Use this for initialization
	void Start () {
        _rend = GetComponent<MeshRenderer>();
        _collectSound = GetComponent<AudioSource>();
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
            _rend.enabled = false;
            _collectSound.Play();
            DestroyDelay();
        }
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}