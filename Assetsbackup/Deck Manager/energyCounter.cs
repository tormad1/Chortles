using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.EventSystems.EventTrigger;
using System;

public class energyCounter : MonoBehaviour
{
    private static TMP_Text Energytext;
    public static int energyValue;
    public static int energyMax;
    public static int tempVal;


    // Start is called before the first frame update
    void Start()
    {
        energyMax = 5;
        energyValue = 5;
        tempVal = energyValue;
        Energytext = GetComponent<TMP_Text>();
        Energytext.text = energyValue.ToString();

    }

    public static void energyChange()
    {
        Energytext.text = tempVal.ToString()+"/5";
        Energytext.color = Color.black;
    }

    public static void energySet()
    {
        Energytext.text = energyValue.ToString() + "/5";
        Energytext.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
