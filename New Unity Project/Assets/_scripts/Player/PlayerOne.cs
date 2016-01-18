using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerOne : Player
{
	// Use this for initialization
	void Start ()
    {
        shootScript = GetComponent<Shoot>();
	}

    protected void FetchInput()
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
               // _anim.SetBool("isJumping", true);
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

        /*if (Input.GetButton("PS4L3_" + joyStickString))
        {
            Movement();
        }*/
    }

    // Update is called once per frame
    void Update ()
    {
        FetchInput();
        Movement();
        PlayerUI();
        ammo = shootScript.GetAmmo();
	}
}