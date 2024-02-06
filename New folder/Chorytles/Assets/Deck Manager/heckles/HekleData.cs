using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class HekleData : MonoBehaviour
{
    [SerializeField] private GameObject Card1;
    [SerializeField] private GameObject Card2;
    [SerializeField] private GameObject Card3;
    [SerializeField] private GameObject Card0;
    public static List<Tuple<int, int, Vector2>> DeckSlots = new List<Tuple<int, int, Vector2>>();
    public static List<Tuple<int, GameObject, int, int, string>> Cards = new List<Tuple<int, GameObject, int, int, string>>();
    public static int SelectedSlot;




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

        DeckSlots = new List<Tuple<int, int, Vector2>>
        {
            //slot, card key, card position on screen
            Tuple.Create(1, 0 , new Vector2(-8, -2.5f)),
            Tuple.Create(2, 1 , new Vector2(-6.5f, -2.5f)),
            Tuple.Create(3, 2 , new Vector2(-5, -2.5f)),
            Tuple.Create(4, 3 , new Vector2(-3.5f, -2.5f)),
            Tuple.Create(5, 4 , new Vector2(-2, -2.5f)),
            Tuple.Create(6, 5 , new Vector2(-0.5f, -2.5f)),
            Tuple.Create(7, 6 , new Vector2(1, -2.5f))
        };

        Cards = new List<Tuple<int, GameObject, int, int, string>>
        {
            //(Type, Card object, Energy, Attack, joke)
            Tuple.Create(0, Card0, 1, 8, "heckle sarc"),
            Tuple.Create(1, Card1, 2, 6, "heckle dry"),
            Tuple.Create(2, Card2, 3, 15, "heckle dark"),
            Tuple.Create(3, Card3, 4, 10, "heckle slap")

        };
    }

    void UpdateDeck()
    {
        Destroy(Card0);
        Destroy(Card1);
        Destroy(Card2);
        Destroy(Card3);
        foreach (Tuple<int, int, Vector2> slot in DeckSlots)
        {
            GameObject CARD = Card0;
            int cardIndex = 0;
            foreach (Tuple<int, GameObject, int, int, string> card in Cards)
            {

                if (cardIndex == slot.Item2)
                {
                    CARD = card.Item2;
                }
                cardIndex++;
            }
            Instantiate(CARD, slot.Item3, new Quaternion(0, 0, 0, 0));
        }
    }

    void FillDeck()
    {
        DeckSlots = new List<Tuple<int, int, Vector2>>
        {
            Tuple.Create(1, Random.Range(0,Cards.Count) , new Vector2(-8, 0.5f)),
        };
    }
}
