using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {

    private int _depositedPieces = 0;
    private int _winningAmountPieces = 4;

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

    void DepositPuzzlePieces(int _depositPieces)
    {
        _depositedPieces += _depositPieces;
    }
}
