using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class HekleData : MonoBehaviour
{
    [SerializeField] public GameObject darkCard;
    [SerializeField] public GameObject sarcasmCard;
    [SerializeField] public GameObject dryCard;
    [SerializeField] public GameObject slapstickCard;
    public static List<Tuple<int, int, Vector2>> DeckSlots = new List<Tuple<int, int, Vector2>>();
    public static List<Tuple<int, GameObject, int, int, string>> darkCards  = new List<Tuple<int, GameObject, int, int, string>>();
    public static List<Tuple<int, GameObject, int, int, string>> sarcasmCards   = new List<Tuple<int, GameObject, int, int, string>>();
    public static List<Tuple<int, GameObject, int, int, string>> dryCards   = new List<Tuple<int, GameObject, int, int, string>>();
    public static List<Tuple<int, GameObject, int, int, string>> slapstickCards   = new List<Tuple<int, GameObject, int, int, string>>();

    public static List<Tuple<int, GameObject, int, int, string>> Cards   = new List<Tuple<int, GameObject, int, int, string>>();

    public static int SelectedSlot;

    public static int attackVal;
    public static int typeVal;




    void Start()
    {
        InitializeLists();
        FillDeck();
        UpdateDeck();
    }


    void Update()
    {

    }
    void InitializeLists()
    {
        SelectedSlot = 0;
        darkCards = new List<Tuple<int, GameObject, int, int, string>>
        {
            //(Type, Card object, Energy, Attack, joke)
            Tuple.Create(0, darkCard, 1, 8, "heckle darkCard"),
            Tuple.Create(0, darkCard, 2, 6, "heckle darkCard"),
            Tuple.Create(0, darkCard, 3, 15, "heckle darkCard"),
            Tuple.Create(0, darkCard, 4, 10, "heckle darkCard")
        };

        sarcasmCards = new List<Tuple<int, GameObject, int, int, string>>
        {
            //(Type, Card object, Energy, Attack, joke)
            Tuple.Create(1, sarcasmCard, 1, 8, "heckle darkCard"),
            Tuple.Create(1, sarcasmCard, 2, 6, "heckle darkCard"),
            Tuple.Create(1, sarcasmCard, 3, 15, "heckle darkCard"),
            Tuple.Create(1, sarcasmCard, 4, 10, "heckle darkCard")
        };

        dryCards = new List<Tuple<int, GameObject, int, int, string>>
        {
            //(Type, Card object, Energy, Attack, joke)
            Tuple.Create(2, dryCard, 1, 8, "heckle darkCard"),
            Tuple.Create(2, dryCard, 2, 6, "heckle darkCard"),
            Tuple.Create(2, dryCard, 3, 15, "heckle darkCard"),
            Tuple.Create(2, dryCard, 4, 10, "heckle darkCard")
        };

        slapstickCards = new List<Tuple<int, GameObject, int, int, string>>
        {
            //(Type, Card object, Energy, Attack, joke)
            Tuple.Create(3, slapstickCard, 1, 8, "heckle darkCard"),
            Tuple.Create(3, slapstickCard, 2, 6, "heckle darkCard"),
            Tuple.Create(3, slapstickCard, 3, 15, "heckle darkCard"),
            Tuple.Create(3, slapstickCard, 4, 10, "heckle darkCard")
        };

        var combined = darkCards.Concat(sarcasmCards).Concat(dryCards).Concat(slapstickCards);
        Cards = combined.ToList();
    }

    public static void UpdateDeck()
    {

        foreach (Tuple<int, int, Vector2> slot in DeckSlots)
        {
            GameObject CARD;
            int cardIndex = 0;
            foreach (Tuple<int, GameObject, int, int, string> card in Cards)
            {

                if (cardIndex == slot.Item2)
                {
                    CARD = card.Item2;
                    attackVal = card.Item4;
                    typeVal = card.Item1;
                    Instantiate(CARD, slot.Item3, new Quaternion(0, 0, 0, 0));
                }
                cardIndex++;
            }
        }
    }

    void FillDeck()
    {
        DeckSlots = new List<Tuple<int, int, Vector2>>
        {
            Tuple.Create(1, Random.Range(0,Cards.Count) , new Vector2(-7.5f, -0.5f)),
        };
    }

    public static void setDeck(int num)
    {
        DeckSlots = new List<Tuple<int, int, Vector2>>
        {
            Tuple.Create(1, num , new Vector2(-7.5f, -0.5f)),
        };
    }
}
