using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compareStage : MonoBehaviour
{
    public static int laughOMeterChange; 

    public static void compareCards()
    {
        float playerAttackAdjusted = DeckData.attackVal * GetMultiplier(DeckData.typeVal, HekleData.typeVal);
        float hecklerAttackAdjusted =HekleData.attackVal * GetMultiplier(HekleData.typeVal, DeckData.typeVal);

        laughOMeterChange = (int)(playerAttackAdjusted - hecklerAttackAdjusted);
        Debug.Log("result = "+laughOMeterChange.ToString());
        Debug.Log("playerAttackAdjusted = "+playerAttackAdjusted.ToString()+" " + DeckData.attackVal);
        Debug.Log("hecklerAttackAdjusted = "+hecklerAttackAdjusted.ToString() +" "+ HekleData.attackVal);
    }

    private static float GetMultiplier(int typeOne, int typeTwo)
    {
        //dark > slap stick > dry > dark
        if ((typeOne == 0 && typeTwo == 3) || (typeOne == 3 && typeTwo == 2) || (typeOne == 2 && typeTwo == 0))
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
        
    }

    void Update()
    {
        
    }
}