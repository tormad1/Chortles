using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;
using static laughMeter;
using TMPro;

public class card : MonoBehaviour
{
    public int cardIndex;
    private Vector2 BasePos;
    public GameObject Energy;
    public GameObject Joke;
    public GameObject Attack;
    private TMP_Text EnergyText;
    private TMP_Text AttackText;
    private TMP_Text JokeText;
    private int type;
    private Tuple<int, GameObject, int, int, string> cardStats;



    // Start is called before the first frame update
    void Start()
    {
        EnergyText = Energy.GetComponent<TMP_Text>();
        AttackText = Attack.GetComponent<TMP_Text>();
        JokeText = Joke.GetComponent<TMP_Text>();


        BasePos = transform.position;
        int i = 0;
        foreach (int slot in DeckData.DeckSlots)
        {
            
            Vector2 pos = transform.position;
            if (pos == DeckData.cardPositions[i])
            {
                cardIndex = i;
                setCardText(slot);
            }

            i++;


        }
    }

    private void OnMouseDown()
    {
        if (roundManager.turn == "Player")
        {
        Debug.Log(cardIndex);
        thisCardSelected();
        }
        else
        {
            Debug.Log(roundManager.turn);
        }
    } 

    void setCardText(int cardkey)
    {
        int i = 0;
        foreach (Tuple<int, GameObject, int, int, string> card in DeckData.Cards)
        {
           
            if (i == cardkey)
            {
                cardStats = card;
            }
            i++;
        }

        EnergyText.fontSize = 1f;
        AttackText.fontSize = 1f;
        JokeText.fontSize = 1f;

        EnergyText.color = Color.white;
        AttackText.color = Color.red;
        JokeText.color = Color.black;

        EnergyText.text = cardStats.Item3.ToString();
        AttackText.text = cardStats.Item4.ToString();
        JokeText.text = cardStats.Item5;

        type = cardStats.Item1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cardSelected();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (cardIndex == DeckData.SelectedSlot) 
            {
                if (energyCounter.energyValue - cardStats.Item3 >= 0)
                {
                    cardUsed();
                    DeckData.isSelected = true;
                }
                else
                {
                    hints.energyHint();
                }
                
            }
        }

 
    }

    void cardSelected()
    {
        if (DeckData.SelectedSlot != cardIndex)
        {
            transform.position = BasePos;
        }
       
    }

    void thisCardSelected()
    {
        if (DeckData.SelectedSlot == cardIndex)
        {
            DeckData.SelectedSlot = 0;
            transform.position = BasePos;
            return;
        }
        else
        {
            Debug.Log("index" + cardIndex);
            Debug.Log("slot" + DeckData.SelectedSlot);
            DeckData.SelectedSlot = cardIndex;

            transform.position = BasePos + new Vector2(0, 1);
        }
    }

    void cardUsed()
    {
        energyCounter.energyValue= energyCounter.energyValue - cardStats.Item3;
        energyCounter.energyChange();
        Debug.Log("index" + cardIndex);
        transform.position = new Vector2(-5.5f, -0.5f);
        DeckData.typeVal = cardStats.Item1;
        Debug.Log(type + " type " + cardStats.Item1);
        DeckData.attackVal = cardStats.Item4;
        DeckData.DeckSlots.RemoveAt(cardIndex);
        DeckData.DeckSlots.Add(DeckData.Cards.Count);
        //Destroy(this.gameObject);

    }

}
