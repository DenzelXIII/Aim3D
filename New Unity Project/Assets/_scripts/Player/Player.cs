using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody _rb;
    protected bool _canJump;
    private int _puzzlePiecesHeld = 0;
    public int joystickNum;


    public float health;

    private Tags _tags;



    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
        _rb = GetComponent<Rigidbody>();
    }


	// Use this for initialization
	void Start ()
    {
        _tags.GIveTag(_tags.playerTag, this.gameObject);
	}

    protected void Movement()
    {

        string joyStickString = joystickNum.ToString();
        transform.Translate(Vector3.forward * speed * Time.deltaTime) ;
        
    }

    protected void Jump()
    {
        Vector3 jumpVector = new Vector3(0, jumpForce, 0);
        _rb.velocity = jumpVector;
    }

    protected void PuzzlePieceCollected(int _collected)
    {
        _puzzlePiecesHeld += _collected;
        Debug.Log(_puzzlePiecesHeld);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Puzzle")
        {
            other.SendMessage("DepositPuzzlePieces", _puzzlePiecesHeld);
            _puzzlePiecesHeld = 0;
        }
    }
}