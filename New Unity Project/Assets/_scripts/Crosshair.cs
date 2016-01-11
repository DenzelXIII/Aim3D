using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
    [SerializeField]private Texture2D crosshairImage;
    [SerializeField]
    private float crosshairPositionX;
    [SerializeField]
    private float crosshairPositionY;

    private int cursorWidth = 32;
    private int cursorHeight = 32;
    private Transform myTransform;
    [SerializeField]private Camera playerCamera;

	// Use this for initialization
	void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        Vector3 screenPos = playerCamera.WorldToScreenPoint(myTransform.position);
        screenPos.y = Screen.height - screenPos.y; 
        GUI.DrawTexture(new Rect(screenPos.x, screenPos.y, cursorWidth, cursorHeight), crosshairImage);
        
    }
}
