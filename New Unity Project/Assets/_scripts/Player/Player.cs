using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Text _puzzlePiecesText;
    
    public float speed;
    public float jumpForce;
    private Rigidbody _rb;
<<<<<<< HEAD
    private bool _canJump;
    private int _puzzlePiecesHeld = 0;

=======
    protected bool _canJump;
    private int _puzzlePiecesHeld = 0;
>>>>>>> origin/master
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
        _puzzlePiecesText.text = "Puzzle Pieces: " + _puzzlePiecesHeld + "/4";
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