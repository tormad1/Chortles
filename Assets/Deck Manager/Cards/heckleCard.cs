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

public class heckleCard : MonoBehaviour
{
    public int cardIndex;
    private Vector2 BasePos;
    public GameObject Energy;
    public GameObject Joke;
    public GameObject Attack;
    private TMP_Text EnergyText;
    private TMP_Text AttackText;
    private TMP_Text JokeText;
    private Tuple<int, GameObject, int, int, string> cardStats;


    // Start is called before the first frame update
    void Start()
    {
        EnergyText = Energy.GetComponent<TMP_Text>();
        AttackText = Attack.GetComponent<TMP_Text>();
        JokeText = Joke.GetComponent<TMP_Text>();


        BasePos = transform.position;
        int i = 0;
        foreach (Tuple<int, int, Vector2> slot in HekleData.DeckSlots)
        {
            i++;
            Vector2 pos = transform.position;
            if (pos == slot.Item3)
            {
                cardIndex = i;
                setCardText(slot.Item2);
            }
        }
    }


    void setCardText(int cardkey)
    {
        int i = 0;
        foreach (Tuple<int, GameObject, int, int, string> card in HekleData.Cards)
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
    }

    void Update()
    {
    }

    void cardUsed()
    {
        Debug.Log("index" + cardIndex);
        UnityEngine.Object.Destroy(this.gameObject);
        laughMeter.laughValue = laughMeter.laughValue + cardStats.Item4;

        laughMeter.laughChange();

    }


}
