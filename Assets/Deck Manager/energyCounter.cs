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
    private static int oldVal;


    // Start is called before the first frame update
    void Start()
    {

        energyValue = 5;
        oldVal = energyValue;
        Energytext = GetComponent<TMP_Text>();
        Energytext.text = energyValue.ToString();

    }

    public static void energyChange()
    {
        Energytext.text = energyValue.ToString();
        Energytext.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
