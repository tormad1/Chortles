using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class DeckData : MonoBehaviour
{
    [SerializeField] private GameObject Card1;
    [SerializeField] private GameObject Card2;
    [SerializeField] private GameObject Card3;
    [SerializeField] private GameObject Card0;
    public static List<Tuple<int, int, Vector2>> DeckSlots = new List<Tuple<int, int, Vector2>>();
    public static List<Tuple<int, GameObject, int, int, string>> Cards = new List<Tuple<int, GameObject, int, int, string>>();
    public static int SelectedSlot;

    public static bool isSelected;

    public static int attackVal;
    public static int typeVal;




    void Start()
    {
        isSelected = false;
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


        Cards = new List<Tuple<int, GameObject, int, int, string>>
        {
            //(Type, Card object, Energy, Attack, joke)
            Tuple.Create(0, Card0, 1, 8, "I'm so good at sleeping, I can do it with my eyes closed."),
            Tuple.Create(1, Card1, 2, 6, "I told my computer I needed a break, and now it won't stop sending me 'get well soon' messages."),
            Tuple.Create(2, Card2, 3, 15, "My therapist says I have a preoccupation with vengeance. We'll see about that."),
            Tuple.Create(3, Card3, 2, 10, "You know you're not in shape when you feel like dying after using a stair master... on the way to the second floor."),
            Tuple.Create(0, Card0, 2, 10, "I'm not saying I'm a procrastinator, but I'll just finish this joke tomorrow."),
            Tuple.Create(1, Card1, 1, 7, "Why do we never tell secrets on a farm? Because the corn has ears."),
            Tuple.Create(2, Card2, 4, 18, "I'd tell you a chemistry joke but I know I wouldn't get a reaction."),
            Tuple.Create(3, Card3, 3, 12, "Why don't skeletons fight each other? They don't have the guts.")

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
            Instantiate(CARD, slot.Item3, new Quaternion(0,0,0,0));
        }
    }

    public static void FillDeck()
    {
        DeckSlots = new List<Tuple<int, int, Vector2>>
        {
            //card type, card key, card position on screen
            Tuple.Create(1, Random.Range(0,Cards.Count) , new Vector2(-8, -3f)),
            Tuple.Create(2, Random.Range(0,Cards.Count) , new Vector2(-6.5f, -3f)),
            Tuple.Create(3, Random.Range(0,Cards.Count) , new Vector2(-5, -3f)),
            Tuple.Create(4, Random.Range(0, Cards.Count), new Vector2(-3.5f, -3f)),
            Tuple.Create(5, Random.Range(0, Cards.Count) , new Vector2(-2, -3f)),
            Tuple.Create(6, Random.Range(0, Cards.Count) , new Vector2(-0.5f, -3f)),
            Tuple.Create(7, Random.Range(0, Cards.Count) , new Vector2(1, -3f))
        };
    }
}
