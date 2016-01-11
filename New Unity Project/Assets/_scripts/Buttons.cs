using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
    private GameObject[] _bases;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void PlayMainMenu()
    {
        Application.LoadLevel("main");
    }

    public void CreditsMainMenu()
    {
        Application.LoadLevel("CreditScreen");
    }

    public void QuitMainMenu()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    { 
        Application.LoadLevel("MainMenu");
    }
}
