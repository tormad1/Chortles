using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class compareStage : MonoBehaviour
{
    public static int laughOMeterChange;
    private static TMP_Text TextVal;
    private static TMP_Text resultText;
    public GameObject resultTextObj;
    public static void compareCards()
    {
        float playerAttackAdjusted = DeckData.attackVal * GetMultiplier(DeckData.typeVal, HekleData.typeVal);
        float hecklerAttackAdjusted =HekleData.attackVal * GetMultiplier(HekleData.typeVal, DeckData.typeVal);

        laughOMeterChange = (int)(playerAttackAdjusted - hecklerAttackAdjusted);
        Debug.Log("result = "+laughOMeterChange.ToString());
        Debug.Log("playerAttackAdjusted = "+playerAttackAdjusted.ToString()+" " + DeckData.typeVal);
        Debug.Log("hecklerAttackAdjusted = "+hecklerAttackAdjusted.ToString() +" "+ HekleData.typeVal);

        TextVal.color = Color.black;

        TextVal.text = "" +  (hecklerAttackAdjusted*-1).ToString() + "/" + playerAttackAdjusted.ToString();
        resultText.text = laughOMeterChange.ToString();


        energyCounter.energyValue = energyCounter.tempVal+2;
        if (energyCounter.energyValue > energyCounter.energyMax)
        {
            energyCounter.energyValue = energyCounter.energyMax;
        }
        energyCounter.tempVal = energyCounter.energyValue;
        energyCounter.energyChange();
        laughMeter.laughValue = laughMeter.laughValue + laughOMeterChange;
        laughMeter.laughChange();
        if(laughOMeterChange > 0){
            hecklerHealth.healthValue = hecklerHealth.healthValue - laughOMeterChange;
            Score.scoreValue = Score.scoreValue + laughOMeterChange*Mathf.CeilToInt(laughMeter.laughValue/10);
        }

        if (hecklerHealth.healthValue<=0)
        {
            hecklerHealth.healthValue=50;
            if (HecklerManager.currentHecklerIndex!=HecklerManager.hecklerDatas.Count){
                HecklerManager.currentHecklerIndex = HecklerManager.currentHecklerIndex + 1;
            }
            else{
                HecklerManager.currentHecklerIndex = 0;
            }
        }
        hecklerHealth.healthChange();
        Score.ScoreChange();
        roundManager.EndRound();

    }

    private static float GetMultiplier(int typeOne, int typeTwo)
    {
        //dark > slap stick > dry > dark
        if ((typeOne == 2 && typeTwo == 3) || (typeOne == 3 && typeTwo == 1) || (typeOne == 1 && typeTwo == 2))
        {
            return 1.5f;
        }
        else
        {
            return 1f;
        }
    }

    void Start()
    {
        TextVal = GetComponent<TMP_Text>();
        resultText = resultTextObj.GetComponent<TMP_Text>();


    }

    void Update()
    {
        
    }
}