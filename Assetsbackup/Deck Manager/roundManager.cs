using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{
    public static int roundNumber = 1;
    public static float laughOMeter = 50.0f; // Start in the middle
    public static float MAX_LAUGH = 100.0f;
    private static float MIN_LAUGH = 0.0f;

    private static card Card;



    public static string turn = "Init";
    void Start()
    {
        InitializeGame();
    }

    private void Update()
    {
        if (roundManager.turn == "Start")
        {
            StartRound();
        }
    }

    void InitializeGame()
    {
        Debug.Log("Game Initialization");
        DeckData.FillDeck();
        StartRound();
    }

    public static void StartRound()
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

    public static void EndRound()
    {
        Debug.Log($"Ending Round {roundNumber}");

        ResetDeck();

        CheckGameEndConditions();

    }


    static void ResetDeck()
    {
        turn = "Reset";
        Debug.Log("kill fail");
    }
    static void CheckGameEndConditions()
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
        }
    }

    public void UpdateLaughOMeter(float amount)
    {
        laughOMeter += amount;
        laughOMeter = Mathf.Clamp(laughOMeter, MIN_LAUGH, MAX_LAUGH);
        Debug.Log($"Laugh-O-Meter is now at {laughOMeter}");
    }
}
