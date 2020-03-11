using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Vector2 thisPosition, otherPosition;
    public bool overlapping;
    public GameObject blankPosition;
    private GameManager _gameManager;
    public int ID;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blank"))
        {
            otherPosition = other.transform.position;
            overlapping = true;
            blankPosition = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        overlapping = false;
    }
    private void OnMouseDown()
    {
        if (overlapping && !_gameManager.isShuffling)
        {
            Move();
        }
    }
    public void Move()
    {
        Vector2 tempPosition = this.transform.position;
        thisPosition = otherPosition;
        this.transform.position = thisPosition;
        blankPosition.transform.position = tempPosition;
    }
}
