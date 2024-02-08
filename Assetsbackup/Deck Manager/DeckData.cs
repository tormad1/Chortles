using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class DeckData : MonoBehaviour
{
    [SerializeField] private GameObject dryObj;
    [SerializeField] private GameObject darkObj;
    [SerializeField] private GameObject slapObj;
    [SerializeField] private GameObject sarcObj;
    [SerializeField] private GameObject blankObj;
    public static List<int> DeckSlots = new List<int>();
    public static List<Tuple<int, GameObject, int, int, string>> Cards = new List<Tuple<int, GameObject, int, int, string>>();
    public static List<Vector2> cardPositions;
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
        if (roundManager.turn == "Reset")
        {
            killCard();
            DrawCard();
        }
    }
    void InitializeLists()
    {
        SelectedSlot = 8;


        Cards = new List<Tuple<int, GameObject, int, int, string>>
        {
            //(Type, Card object, Energy, Attack, joke)
            Tuple.Create(0, sarcObj, 1, 8, "I'm so good at sleeping, I can do it with my eyes closed."),
            Tuple.Create(1, dryObj, 2, 6, "I told my computer I needed a break, and now it won't stop sending me 'get well soon' messages."),
            Tuple.Create(2, darkObj, 3, 15, "My therapist says I have a preoccupation with vengeance. We'll see about that."),
            Tuple.Create(3, slapObj, 2, 10, "You know you're not in shape when you feel like dying after using a stair master... on the way to the second floor."),
            Tuple.Create(0, sarcObj, 2, 10, "I'm not saying I'm a procrastinator, but I'll just finish this joke tomorrow."),
            Tuple.Create(1, dryObj, 1, 7, "Why do we never tell secrets on a farm? Because the corn has ears."),
            Tuple.Create(2, darkObj, 4, 18, "I'd tell you a chemistry joke but I know I wouldn't get a reaction."),
            Tuple.Create(3, slapObj, 3, 12, "Why don't skeletons fight each other? They don't have the guts."),
            Tuple.Create(4, blankObj, 0, 0, "blank spot")

        };
    }

    void UpdateDeck()
    {
        int slotIndex=0;
        foreach (int slot in DeckSlots)
        {
            GameObject CARD;
            int cardIndex = 0;
            foreach (Tuple<int, GameObject, int, int, string> card in Cards)
            {
                
                if (cardIndex == slot)
                {
                    CARD = card.Item2;
                    Instantiate(CARD, cardPositions[slotIndex], new Quaternion(0, 0, 0, 0));
                }
                cardIndex++;
            }
            slotIndex++;
        }
    }

    public static void FillDeck()
    {
        DeckSlots = new List<int>
        {
            Random.Range(0,Cards.Count - 1),
            Random.Range(0,Cards.Count - 1),
            Random.Range(0,Cards.Count - 1),
            Random.Range(0, Cards.Count - 1),
            Random.Range(0, Cards.Count-1),
            Random.Range(0, Cards.Count-1),
            Random.Range(0, Cards.Count-1)
        };

        cardPositions = new List<Vector2>()
        {
            new Vector2(-8, -3.5f),
            new Vector2(-6.5f, -3.5f),
            new Vector2(-5, -3.5f),
            new Vector2(-3.5f, -3.5f),
            new Vector2(-2, -3.5f),
            new Vector2(-0.5f, -3.5f),
            new Vector2(1, -3.5f)
        };
    }


    private void DrawCard()
    {
        int i = 0;
        foreach (int slot in DeckSlots)
        {
            if (slot == Cards.Count)
            {
                DeckSlots.RemoveAt(i);
                DeckSlots.Add(Random.Range(0, Cards.Count - 1));
            }
            i++;
        }
        UpdateDeck();

    }

    public void killCard()
    {
        var gos = GameObject.FindGameObjectsWithTag("card");
        foreach (var go in gos) {
            Destroy(go); 
        }
        Debug.Log("kill succsess");
        UpdateDeck();
        roundManager.turn = "Start";
    }
}
