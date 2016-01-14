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
        Application.LoadLevel("truefinalscene");
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

    public void HowToPlay()
    {
        Application.LoadLevel("HowToPlayScene");
    }
}
