using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{
    public int roundNumber = 1;
    public float laughOMeter = 50.0f; // Start in the middle
    public float MAX_LAUGH = 100.0f;
    private float MIN_LAUGH = 0.0f;

    public static string turn = "Init";
    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        Debug.Log("Game Initialization");
        DeckData.FillDeck();
        StartRound();
    }

    public void StartRound()
    {
        Debug.Log($"Starting Round {roundNumber}");
        HecklerTurn();
    }

    public static void PlayerTurn()
    {
        Debug.Log("Player's Turn");
        turn = "Player";
    }

    public static void HecklerTurn()
    {
        Debug.Log("Heckler's Turn");
        turn = "heckler";
        HecklerManager.PlayHecklerCard();
        PlayerTurn();
    }

    public static void CompareCards()
    {
        Debug.Log("Comparing Cards");
        turn = "compare";
        compareStage.compareCards();
    }

    public void EndRound()
    {
        Debug.Log($"Ending Round {roundNumber}");
        CheckGameEndConditions();
    }

    void CheckGameEndConditions()
    {
        if (laughOMeter >= MAX_LAUGH)
        {
            Debug.Log("Player has won the game!");
        }
        else if (laughOMeter <= MIN_LAUGH)
        {
            Debug.Log("Player has lost the game!");
        }
        else
        {
            roundNumber++;
            StartRound();
        }
    }

    public void UpdateLaughOMeter(float amount)
    {
        laughOMeter += amount;
        laughOMeter = Mathf.Clamp(laughOMeter, MIN_LAUGH, MAX_LAUGH);
        Debug.Log($"Laugh-O-Meter is now at {laughOMeter}");
    }
}
