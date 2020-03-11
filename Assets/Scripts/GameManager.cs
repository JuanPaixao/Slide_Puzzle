using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int shuffleNumber;
    public Puzzle[] puzzleTemp;
    public List<Puzzle> puzzle = new List<Puzzle>();
    public int randomValue, lastRandomValue;
    public bool isShuffling, isTesting;
    public bool piece01, piece02, piece03, piece04, piece05, piece06, piece07, piece08;
    public GameObject[] puzzleDetectors;

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ButtonClicked()
    {
        Debug.Log("Button clicked");
    }
    private void Shuffle()
    {
        puzzleTemp = FindObjectsOfType<Puzzle>();
        puzzle.Clear();

        foreach (var item in puzzleTemp)
        {
            puzzle.Add(item);
        }
        bool stop = false;
        randomValue = Random.Range(0, puzzle.Count + 1);
        if (randomValue != lastRandomValue)
        {
            randomValue = Random.Range(0, puzzle.Count + 1);
        }
        lastRandomValue = randomValue;
        for (int i = randomValue; i < puzzle.Count; i++)
        {
            if (puzzle[i].overlapping && !stop)
            {
                puzzle[i].Move();
                stop = true;
            }
        }
    }
    public void ShuffleGame()
    {
        if (!isShuffling)
        {
            StartCoroutine(ShuffleRoutine());
        }
    }
    public void TestGame()
    {
        if (!isTesting)
        {
            StartCoroutine(TestRoutine());
        }
    }
    public void WinCondition()
    {
        if (piece01 && piece02 && piece03 && piece04 && piece05 && piece06 && piece07 && piece08)
        {
            Debug.Log("Finished! You win!");
        }
        else
        {
            Debug.Log("Not Finished!");
        }
    }
    public IEnumerator ShuffleRoutine()
    {
        isShuffling = true;
        for (int i = 0; i < shuffleNumber; i++)
        {
            yield return new WaitForSeconds(0.03f);
            Shuffle();
        }
        Debug.Log("Shuffle Finished");
        isShuffling = false;
    }
    public IEnumerator TestRoutine()
    {
        isTesting = true;
        foreach (var item in puzzleDetectors)
        {
            item.SetActive(true);
        }
        yield return new WaitForSeconds(0.2f);
        TestGame();
        foreach (var item in puzzleDetectors)
        {
            item.SetActive(false);
        }
        isTesting = false;
        WinCondition();
    }
    public void PieceRightPosition(int i, bool state)
    {
        switch (i)
        {
            case 1:
                FindObjectOfType<GameManager>().piece01 = state;
                break;
            case 2:
                FindObjectOfType<GameManager>().piece02 = state;
                break;
            case 3:
                FindObjectOfType<GameManager>().piece03 = state;
                break;
            case 4:
                FindObjectOfType<GameManager>().piece04 = state;
                break;
            case 5:
                FindObjectOfType<GameManager>().piece05 = state;
                break;
            case 6:
                FindObjectOfType<GameManager>().piece06 = state;
                break;
            case 7:
                FindObjectOfType<GameManager>().piece07 = state;
                break;
            case 8:
                FindObjectOfType<GameManager>().piece08 = state;
                break;
        }
    }
}
