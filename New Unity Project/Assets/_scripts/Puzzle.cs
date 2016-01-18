using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {

    private float _depositedPieces = 0;
    private float _winningAmountPieces = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (_depositedPieces == _winningAmountPieces)
        {
            Application.LoadLevel("WinScene");
        }
	
	}

    void DepositPuzzlePieces(float _depositPieces)
    {
        _depositedPieces += _depositPieces;
    }
}
