﻿using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
    public float lookSensitivity = 5;
    public float xRotation;
    public float yRotation;
    public float currentXRotation;
    public float currentYRotation;
    public float yRotationV;
    public float lookSmoothness = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        yRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;

        transform.rotation = Quaternion.Euler(xRotation, yRotation,0);
    }
}
