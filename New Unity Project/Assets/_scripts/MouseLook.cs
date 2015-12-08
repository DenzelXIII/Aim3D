using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
   /* public float lookSensitivity = 5;
    public float xRotation;
    public float yRotation;
    public float currentXRotation;
    public float currentYRotation;
    public float yRotationV;
    public float lookSmoothness = 0.1f;*/


    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2}
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15f;
    public float sensitivityY = 15f;

    public float minX = -360f;
    public float maxX = 360f;

    public float minY = -60f;
    public float maxY = 60f;

    float rotationY = 0f;
    public int joysticknum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        yRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;

        transform.rotation = Quaternion.Euler(xRotation, yRotation,0);*/

         string joystickString = joysticknum.ToString();

        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("PS4R3HORIZONTAL"+joysticknum) * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("PS4R3VERTICAL"+joysticknum) * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(rotationY, transform.localEulerAngles.y, 0);
        }

    }
}
