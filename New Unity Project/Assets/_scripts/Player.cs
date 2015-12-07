using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;


	// Use this for initialization
	void Start () {
	
	}

    void FetchInput()
    {
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            print("Pressing Square");

        }

        if (Input.GetKey(KeyCode.Joystick1Button1))
        {
            print("Pressing X");
        }

        if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            print("Pressing Circle");
        }

        if (Input.GetKey(KeyCode.Joystick1Button3))
        {
            print("Pressing Triangle");
        }

        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            print("Pressing L1");
        }

        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            print("Pressing R1");
        }
    }
	
    void Movement()
    {
        float v = speed * Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 movementVector = new Vector3(0, 0, v);
        transform.Translate(movementVector);
        Debug.Log(v);
    }

	// Update is called once per frame
	void Update ()
    {
        FetchInput();
        Movement();
    }
}
