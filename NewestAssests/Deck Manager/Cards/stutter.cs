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

public class stutter : MonoBehaviour
{
    private Vector3 BasePos;
    private Vector3 BaseScale;



    // Start is called before the first frame update
    void Start()
    {
        BasePos = transform.position;
        BaseScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        if (roundManager.turn == "Player")
        {
        thisCardSelected();
        }
        else
        {
            Debug.Log(roundManager.turn);
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
            if (transform.localScale != BaseScale) 
            {
                cardUsed();
            }
        }

 
    }

    void cardSelected()
    {
        if (DeckData.SelectedSlot != -1)
        {
            transform.position = BasePos;
            transform.localScale = BaseScale;
        }
    }

    void thisCardSelected()
    {
        if (transform.localScale != BaseScale)
        {
            DeckData.SelectedSlot = -1;
            transform.position = BasePos;
            transform.localScale = BaseScale;
            return;
        }
        else
        {
            DeckData.SelectedSlot = -1;
            transform.localScale = new Vector3(BaseScale.x * 1.2f, BaseScale.y * 1.2f);
        }
    }

    void cardUsed()
    {
        transform.localScale = new Vector3(BaseScale.x * 1.2f, BaseScale.y * 1.2f);
        transform.position = new Vector2(-4.5f, -1);

    }

}
