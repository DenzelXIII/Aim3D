using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody _rb;
    private bool _canJump;
<<<<<<< HEAD:New Unity Project/Assets/_scripts/Player/Player.cs
=======
    private int _puzzlePiecesHeld = 0;

>>>>>>> 77fee1a96227e703ee215ad388224eb79218d06c:New Unity Project/Assets/_scripts/Player.cs
    public int joystickNum;
    public float health;



    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


	// Use this for initialization
	void Start () {
	
	}

    void FetchInput()
    {

        string joyStickString = joystickNum.ToString();
        if (Input.GetButton("PS4OBUTTON" + joyStickString))
        {
            print("Pressing Square");

        }

        if (Input.GetButton("PS4XBUTTON" + joyStickString))
        {
            print("Pressing X");
            _canJump = true;
            if (_canJump)
            {
                Jump();
                _canJump = false;
            }

        }

        if (Input.GetButton("PS4OBUTTON" + joyStickString))
        {
            print("Pressing Circle");
        }

        if (Input.GetButton("PS4TRIANGLEBUTTON" + joyStickString))
        {
            print("Pressing Triangle");
        }

        if (Input.GetButton("PS4L1_" + joyStickString))
        {
            print("Pressing L1");
        }

        if (Input.GetButton("PS4R1_" + joyStickString))
        {
            print("Pressing R1");
        }

        if (Input.GetButton("PS4L3_" +joyStickString))
        {
            Movement();
        }
    }

    void Movement()
    {

        string joyStickString = joystickNum.ToString();
        transform.Translate(Vector3.forward * speed * Time.deltaTime) ;
        
    }

    void Jump()
    {
        Vector3 jumpVector = new Vector3(0, jumpForce, 0);
        _rb.velocity = jumpVector;
    }

	// Update is called once per frame
	void Update ()
    {
        FetchInput();
    }

    void PuzzlePieceCollected(int _collected)
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