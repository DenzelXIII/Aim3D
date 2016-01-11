using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody _rb;
    private bool _canJump;
    private int _puzzlePiecesHeld = 0;

    public int joystickNum;



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

        else if (Input.GetButton("PS3_Circle_Button" + joyStickString))
        {
            print("Pressing PS3_Circle");
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
       // float v = speed * Input.GetAxis("Vertical" + joyStickString) * Time.deltaTime;
        //Vector3 movementVector = new Vector3(0, 0, v);
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