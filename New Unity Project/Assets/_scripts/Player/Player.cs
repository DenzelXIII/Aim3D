using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Text _puzzlePiecesText;

    public Shoot shootScript;

    public Image ammoBar;
    public Image healthBar;
    
    public float speed;
    public float jumpForce;
    private Rigidbody _rb;

    protected bool _canJump;
    private int _puzzlePiecesHeld = 0;

    public int joystickNum;


    public float health;
    public float healthBarOffSet = 10;

    public float ammo;
    public float ammoOffSet = 30;

    private Tags _tags;
    private Animator _anim;



    void Awake()
    {
        _anim = GetComponent<Animator>();
        _tags = FindObjectOfType<Tags>();
        _rb = GetComponent<Rigidbody>();
    }


	// Use this for initialization
	void Start ()
    {
        _tags.GiveTag(_tags.playerTag, this.gameObject);
	}

    protected void Movement()
    {

        string joyStickString = joystickNum.ToString();

        float h = Input.GetAxis("Vertical") * speed;
        Vector3 movementVector = new Vector3(0, 0, h) * Time.deltaTime;
        //transform.Translate(movementVector);
        //_rb.velocity = movementVector;
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





