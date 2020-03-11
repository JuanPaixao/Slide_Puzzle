using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDetector : MonoBehaviour
{
    public int ID;
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.ID.ToString() == other.gameObject.name)
        {
            _gameManager.PieceRightPosition(this.ID, true);
        }
        if (this.ID.ToString() != other.gameObject.name)
        {
            _gameManager.PieceRightPosition(this.ID, false);
        }
    }
}
