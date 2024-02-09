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
    private Vector2 BaseScale;
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
        BaseScale = transform.localScale;
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

                EnergyText.fontSize = 1f;
                AttackText.fontSize = 1.5f;
                JokeText.fontSize = 1f;

                EnergyText.color = Color.white;
                AttackText.color = Color.red;
                JokeText.color = Color.black;

                EnergyText.text = cardStats.Item3.ToString();
                AttackText.text =" "+ cardStats.Item4.ToString();
                JokeText.text = cardStats.Item5;

                type = cardStats.Item1;
            }
            i++;
        }
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
                    Debug.Log("HEYHEYHEY FUck u. plez fuix me");
                    
                    cardUsed();
                    
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
            transform.localScale = BaseScale;
        }
    }

    void thisCardSelected()
    {
        if (DeckData.SelectedSlot == cardIndex)
        {
            DeckData.SelectedSlot = -1;
            transform.position = BasePos;
            transform.localScale = BaseScale;
            energyCounter.tempVal = energyCounter.energyValue;
            return;
        }
        else
        {
            energyCounter.tempVal = energyCounter.energyValue;
            Debug.Log("index" + cardIndex);
            Debug.Log("slot" + DeckData.SelectedSlot);
            DeckData.SelectedSlot = cardIndex;
            transform.localScale = new Vector3(BaseScale.x * 1.2f, BaseScale.y * 1.2f);
        }
    }

    void cardUsed()
    {
        transform.localScale = new Vector3(BaseScale.x * 1.2f, BaseScale.y * 1.2f);
        energyCounter.tempVal = energyCounter.energyValue - cardStats.Item3;
        Debug.Log("index" + cardIndex);
        transform.position = new Vector2(-4.5f, -1);
        DeckData.typeVal = cardStats.Item1;
        Debug.Log(type + " type " + cardStats.Item1);
        DeckData.attackVal = cardStats.Item4;

    }

}
